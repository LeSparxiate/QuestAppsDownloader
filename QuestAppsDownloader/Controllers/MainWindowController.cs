using System.Data;
using QuestAppsDownloader.DTO.DTOs;
using QuestAppsDownloader.Services.Implementations.Tools;
using QuestAppsDownloader.Services.Interfaces.Proxy;
using QuestAppsDownloader.Services.Interfaces.Services;
using QuestAppsDownloader.Services.Interfaces.Tools;

namespace QuestAppsDownloader.Controllers;

public class MainWindowController
{
    private readonly IRCloneService _rcloneService;
    private readonly IVRPProxy _vrpProxy;
    private readonly IFileManager _fileManager;

    public DataTable Metadata { get; set; }

    public MainWindowController(IRCloneService rcloneService, IVRPProxy vrpProxy, IFileManager fileManager)
    {
        _rcloneService = rcloneService;
        _vrpProxy = vrpProxy;
        _fileManager = fileManager;
    }

    public async Task SetupRclone()
    {
        await _rcloneService.SetupRclone();
    }

    public Task<VRPPublic> SetupVRPPublic()
    {
        return _vrpProxy.GetVRPPublic();
    }

    public async Task GetMetadata(VRPPublic vrpPublic)
    {
        await _rcloneService.SetupMetadata(vrpPublic);
    }

    public void LoadMetadata()
    {
        Metadata = MetadataManager.LoadMetadata();
    }

    public void DownloadGame(string releaseName, VRPPublic vrpPublic)
    {
        _rcloneService.DownloadGame(releaseName, vrpPublic);
    }

    public void DeleteDirectory(string directoryPath)
    {
        _fileManager.DeleteDirectory(directoryPath);
    }
}
