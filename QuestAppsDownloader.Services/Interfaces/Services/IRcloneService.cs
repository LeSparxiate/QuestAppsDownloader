namespace QuestAppsDownloader.Services.Interfaces.Services;

public interface IRcloneService
{
    Task SetupRclone();
    Task SetupMetadata();
    Task DownloadGame(string releaseName);
}
