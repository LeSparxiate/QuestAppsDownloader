using System.Net;
using FluentAssertions;
using NSubstitute;
using QuestAppsDownloader.Services.Implementations.Wrappers;
using Xunit;

namespace QuestAppsDownloader.Services.Tests.Wrappers;

public class HttpWrapperTests
{
    private const string Url = "http://google.com";

    private readonly HttpClient _httpClient;

    private readonly HttpWrapper _subject;

    public HttpWrapperTests()
    {
        _httpClient = Substitute.For<HttpClient>();

        _subject = new HttpWrapper(_httpClient);
    }

    [Fact]
    public async Task SendAsync_WhenGetRequestSucceeds_ThenReturnsStatusCodeOK()
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, Url);

        var response = await _subject.SendAsync(httpRequest);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task DownloadFileAsync_GetFileBytes()
    {
        var outputPath = "./output";

        await _subject.DownloadFileAsync(Url, outputPath);

        await _httpClient.Received(1).GetByteArrayAsync(Url);
    }
}
