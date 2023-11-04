using System.Diagnostics.CodeAnalysis;
using QuestAppsDownloader.Services.Exceptions;
using QuestAppsDownloader.Services.Interfaces.Tools;
using QuestAppsDownloader.Services.Interfaces.Wrappers;
using RcloneWrapper;
using RcloneWrapper.OptionsBuilders;

namespace QuestAppsDownloader.Services.Implementations.Wrappers;

[ExcludeFromCodeCoverage]
public class RCloneWrapper : IRCloneWrapper
{
    private const string RcloneDirectoryPath = "./rclone";
    private const string RcloneExecutable = "rclone.exe";

    private readonly IFileManager _fileManager;

    public RCloneWrapper(IFileManager fileManager)
    {
        _fileManager = fileManager;
    }

    public async Task SyncAsync(string baseUri, string remotePathSrc, string remotePathDst)
    {
        var builder = CommandLineBuilder.Sync(remotePathSrc, remotePathDst, options: new HTTP_OptionsBuilder { Url = baseUri });
        var rcloneProcess = new Rclone { RcloneExe = _fileManager.GetFilePath(RcloneDirectoryPath, RcloneExecutable) };

        var progress = new Progress<int>(percent => Console.WriteLine($"progress : {percent}"));

        try
        {
            await rcloneProcess.RunAsync(builder, progress);
        }
        catch
        {
            throw new RCloneCloudException(baseUri);
        }
    }

    public async Task CopyAsync(string baseUri, string remotePathSrc, string remotePathDst)
    {
        var builder = CommandLineBuilder.Copy(remotePathSrc, remotePathDst,
            options: new HTTP_OptionsBuilder
            {
                Url = baseUri,
                CustomOptions = new Dictionary<string, string> {
                    { "--quiet", "" },
                    { "--progress", "" },
                    { "--stats-one-line", "" }
                }
            });
        var rcloneProcess = new Rclone { RcloneExe = _fileManager.GetFilePath(RcloneDirectoryPath, RcloneExecutable) };

        var progress = new Progress<int>();
        progress.ProgressChanged += Progress_ProgressChanged;

        try
        {
            await rcloneProcess.RunAsync(builder, progress);
        }
        catch
        {
            throw new RCloneCloudException(baseUri);
        }
    }

    private void Progress_ProgressChanged(object sender, int e)
    {
        Console.WriteLine($"Downloaded {e}%");
    }
}
