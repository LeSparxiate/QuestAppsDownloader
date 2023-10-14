using System.Data;
using QuestAppsDownloader.DTO.DTOs;
using QuestAppsDownloader.Services.Implementations.Tools;
using QuestAppsDownloader.Services.Interfaces.Proxy;
using QuestAppsDownloader.Services.Interfaces.Services;

namespace QuestAppsDownloader.Controllers;

public class MainWindowController
{
    private readonly IRcloneService _rcloneService;
    private readonly IVRPProxy _vrpProxy;

    public DataTable Metadata { get; set; }

    public MainWindowController(IRcloneService rcloneService, IVRPProxy vrpProxy)
    {
        _rcloneService = rcloneService;
        _vrpProxy = vrpProxy;
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
}
