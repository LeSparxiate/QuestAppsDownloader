namespace QuestAppsDownloader.Services.Interfaces.Wrappers;

public interface IRCloneWrapper
{
    Task SyncAsync(string baseUri, string remotePathSrc, string remotePathDst);
    Task CopyAsync(string baseUri, string remotePathSrc, string remotePathDst);
}
