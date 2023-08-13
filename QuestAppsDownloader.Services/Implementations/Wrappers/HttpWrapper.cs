using QuestAppsDownloader.Services.Interfaces.Wrappers;

namespace QuestAppsDownloader.Services.Implementations.Wrappers;

public class HttpWrapper : IHttpWrapper
{
    private readonly HttpClient _httpClient;

    public HttpWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
    {
        return _httpClient.SendAsync(request);
    }

    public async Task DownloadFileAsync(string uri, string outputPath)
    {
        var fileBytes = await _httpClient.GetByteArrayAsync(uri);
        File.WriteAllBytes(outputPath, fileBytes);
    }
}