using QuestAppsDownloader.DTO.DTOs;

namespace QuestAppsDownloader.Services.Interfaces.Services;

public interface IRCloneService
{
    Task SetupRclone();
    Task SetupMetadata(VRPPublic vrpPublic);
    Task DownloadGame(string releaseName, VRPPublic vrpPublic);
}
