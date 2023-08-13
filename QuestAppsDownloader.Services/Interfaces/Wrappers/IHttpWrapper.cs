namespace QuestAppsDownloader.Services.Interfaces.Wrappers;

public interface IHttpWrapper
{
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    Task DownloadFileAsync(string uri, string outputPath);
}