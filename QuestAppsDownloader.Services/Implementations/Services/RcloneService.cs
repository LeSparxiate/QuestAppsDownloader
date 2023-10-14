using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using QuestAppsDownloader.DTO.DTOs;
using QuestAppsDownloader.Services.Configurations;
using QuestAppsDownloader.Services.Implementations.Tools;
using QuestAppsDownloader.Services.Interfaces.Services;
using QuestAppsDownloader.Services.Interfaces.Wrappers;
using RcloneWrapper;
using RcloneWrapper.OptionsBuilders;

namespace QuestAppsDownloader.Services.Implementations.Services;

public class RcloneService : IRcloneService
{
    private const string RcloneArchivePath = "./rclone.zip";
    private const string RcloneDirectoryPath = "./rclone";
    private const string RcloneExecutable = "rclone.exe";
    private const string MetadataDirectoryPath = "./metadata";
    private const string MetadataArchive = "meta.7z";
    private const string DownloadsFolderPath = "./downloads";

    private readonly IHttpWrapper _httpWrapper;
    private readonly MetadataConfiguration _metadataConfiguration;
    private readonly RcloneConfiguration _rcloneConfiguration;

    public RcloneService(IHttpWrapper httpWrapper,
        IOptions<MetadataConfiguration> metadataConfiguration,
        IOptions<RcloneConfiguration> rcloneConfiguration)
    {
        _httpWrapper = httpWrapper;
        _metadataConfiguration = metadataConfiguration.Value;
        _rcloneConfiguration = rcloneConfiguration.Value;
    }

    public async Task SetupRclone()
    {
        await _httpWrapper.DownloadFileAsync(_rcloneConfiguration.DownloadUrl, RcloneArchivePath);
        FileManager.UnzipArchive(RcloneArchivePath, RcloneDirectoryPath);
        FileManager.DeleteFile(RcloneArchivePath);
    }

    public async Task SetupMetadata(VRPPublic vrpPublic)
    {
        FileManager.CreateDirectory(MetadataDirectoryPath);

        var builder = CommandLineBuilder.Sync(_metadataConfiguration.MetadataCloudPath, MetadataDirectoryPath, options: new HTTP_OptionsBuilder { Url = vrpPublic.BaseUri });
        var rcloneProcess = new Rclone { RcloneExe = FileManager.GetFilePath(RcloneDirectoryPath, RcloneExecutable) };

        var progress = new Progress<int>(percent => Console.WriteLine($"progress : {percent}"));
        var result = await rcloneProcess.RunAsync(builder, progress);

        FileManager.Unzip7zArchive($"{MetadataDirectoryPath}/{MetadataArchive}", MetadataDirectoryPath, vrpPublic.GetDecodedPassword());
    }

    public async Task DownloadGame(string releaseName, VRPPublic vrpPublic)
    {
        var md5ReleaseName = ConvertReleaseNameToMD5(releaseName);
        var destinationDirectory = $"{DownloadsFolderPath}/{md5ReleaseName}";
        FileManager.CreateDirectory(DownloadsFolderPath);
        FileManager.CreateDirectory(destinationDirectory);

        var builder = CommandLineBuilder.Copy($":http:/{md5ReleaseName}/", destinationDirectory,
            options: new HTTP_OptionsBuilder
            {
                Url = vrpPublic.BaseUri,
                CustomOptions = new Dictionary<string, string> {
                    { "--quiet", "" },
                    { "--progress", "" },
                    { "--stats-one-line", "" }
                }
            });
        var rcloneProcess = new Rclone { RcloneExe = FileManager.GetFilePath(RcloneDirectoryPath, RcloneExecutable) };

        var progress = new Progress<int>();
        progress.ProgressChanged += Progress_ProgressChanged;
        var result = await rcloneProcess.RunAsync(builder, progress);

        var files = FileManager.GetFilesInDirectory(destinationDirectory, "*.7z*");

        Console.WriteLine($"Extracting game, please wait...");
        FileManager.Unzip7zArchive(files.First(), destinationDirectory, vrpPublic.GetDecodedPassword());
        Console.WriteLine($"Extraction complete!");
    }

    private void Progress_ProgressChanged(object sender, int e)
    {
        Console.WriteLine($"Downloaded {e}%");
    }

    private static string ConvertReleaseNameToMD5(string releaseName)
    {
        var md5ReleaseName = string.Empty;

        using (var md5 = MD5.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(releaseName + "\n");
            var hash = md5.ComputeHash(bytes);
            var sb = new StringBuilder();

            foreach (var b in hash)
                sb.Append(b.ToString("x2"));

            md5ReleaseName = sb.ToString();
        }

        return md5ReleaseName;
    }
}
