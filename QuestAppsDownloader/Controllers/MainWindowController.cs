using QuestAppsDownloader.Services.Implementations.Tools;
using QuestAppsDownloader.Services.Interfaces.Services;
using System.Data;

namespace QuestAppsDownloader.Controllers;

public class MainWindowController
{
    private readonly IRcloneService _rcloneService;

    public DataTable Metadata { get; set; }

    public MainWindowController(IRcloneService rcloneService)
    {
        _rcloneService = rcloneService;
    }

    public async Task SetupRclone()
    {
        await _rcloneService.SetupRclone();
    }

    public async Task GetMetadata()
    {
        await _rcloneService.SetupMetadata();
    }

    public void LoadMetadata()
    {
        Metadata = MetadataManager.LoadMetadata();
    }

    public void DownloadGame(string releaseName)
    {
        _rcloneService.DownloadGame(releaseName);
    }
}
