using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using QuestAppsDownloader.DTO.DTOs;
using QuestAppsDownloader.Services.Configurations;
using QuestAppsDownloader.Services.Exceptions;
using QuestAppsDownloader.Services.Interfaces.Services;
using QuestAppsDownloader.Services.Interfaces.Tools;
using QuestAppsDownloader.Services.Interfaces.Wrappers;

namespace QuestAppsDownloader.Services.Implementations.Services;

public class RCloneService : IRCloneService
{
    private const string RcloneArchivePath = "./rclone.zip";
    private const string RcloneDirectoryPath = "./rclone";
    private const string RcloneExecutable = "rclone.exe";
    private const string MetadataDirectoryPath = "./metadata";
    private const string MetadataArchive = "meta.7z";
    private const string DownloadsFolderPath = "./downloads";

    private readonly IHttpWrapper _httpWrapper;
    private readonly IFileManager _fileManager;
    private readonly IRCloneWrapper _rcloneWrapper;
    private readonly MetadataConfiguration _metadataConfiguration;
    private readonly RcloneConfiguration _rcloneConfiguration;

    public RCloneService(IHttpWrapper httpWrapper, IFileManager fileManager, IRCloneWrapper rcloneWrapper,
        IOptions<MetadataConfiguration> metadataConfiguration,
        IOptions<RcloneConfiguration> rcloneConfiguration)
    {
        _httpWrapper = httpWrapper;
        _fileManager = fileManager;
        _rcloneWrapper = rcloneWrapper;
        _metadataConfiguration = metadataConfiguration.Value;
        _rcloneConfiguration = rcloneConfiguration.Value;
    }

    public async Task SetupRclone()
    {
        if (string.IsNullOrEmpty(_fileManager.GetFilePath(RcloneDirectoryPath, RcloneExecutable)))
        {
            await DownloadRclone();
            _fileManager.UnzipArchive(RcloneArchivePath, RcloneDirectoryPath);
            _fileManager.DeleteFile(RcloneArchivePath);
        }
    }

    public async Task SetupMetadata(VRPPublic vrpPublic)
    {
        _fileManager.CreateDirectory(MetadataDirectoryPath);
        await _rcloneWrapper.SyncAsync(vrpPublic.BaseUri, _metadataConfiguration.MetadataCloudPath, MetadataDirectoryPath);
        _fileManager.Unzip7zArchive($"{MetadataDirectoryPath}/{MetadataArchive}", MetadataDirectoryPath, vrpPublic.GetDecodedPassword());
    }

    public async Task DownloadGame(string releaseName, VRPPublic vrpPublic)
    {
        var md5ReleaseName = ConvertReleaseNameToMD5(releaseName);
        var destinationDirectory = $"{DownloadsFolderPath}/{md5ReleaseName}";
        _fileManager.CreateDirectory(DownloadsFolderPath);
        _fileManager.CreateDirectory(destinationDirectory);

        await _rcloneWrapper.CopyAsync(vrpPublic.BaseUri, $":http:/{md5ReleaseName}/", destinationDirectory);

        var files = _fileManager.GetFilesInDirectory(destinationDirectory, "*.7z*");

        Console.WriteLine($"Extracting game, please wait...");
        _fileManager.Unzip7zArchive(files.First(), destinationDirectory, vrpPublic.GetDecodedPassword());
        Console.WriteLine($"Extraction complete!");
    }

    private async Task DownloadRclone()
    {
        try
        {
            await _httpWrapper.DownloadFileAsync(_rcloneConfiguration.DownloadUrl, RcloneArchivePath);
        }
        catch
        {
            try
            {
                await _httpWrapper.DownloadFileAsync(_rcloneConfiguration.AlternativeUrl, RcloneArchivePath);
            }
            catch
            {
                throw new RCloneSetupException();
            }
        }
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
