using System.Net;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NSubstitute;
using QuestAppsDownloader.DTO.DTOs;
using QuestAppsDownloader.Services.Configurations;
using QuestAppsDownloader.Services.Exceptions;
using QuestAppsDownloader.Services.Implementations.Proxy;
using QuestAppsDownloader.Services.Interfaces.Wrappers;
using Xunit;

namespace QuestAppsDownloader.Services.Tests.Proxy;

public class VRPProxyTests
{
    private static readonly IFixture Auto = new Fixture();

    private readonly IHttpWrapper _httpWrapper;
    private readonly VRPPublicConfiguration _vrpPublicConfiguration;

    private readonly VRPProxy _subject;

    public VRPProxyTests()
    {
        _httpWrapper = Substitute.For<IHttpWrapper>();
        _vrpPublicConfiguration = new VRPPublicConfiguration { Url = "http://google.com/" };

        _subject = new VRPProxy(_httpWrapper, Options.Create(_vrpPublicConfiguration));
    }

    [Fact]
    public async Task GetVRPPublic_ThenReturnsExpectedVrpPublic()
    {
        var expectedVrpPublic = Auto.Create<VRPPublic>();
        var expectedVrpPublicJson = JsonConvert.SerializeObject(expectedVrpPublic);
        var httpResponse = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(expectedVrpPublicJson) };
        _httpWrapper.SendAsync(Arg.Is<HttpRequestMessage>(r => r.RequestUri.ToString() == _vrpPublicConfiguration.Url)).Returns(httpResponse);

        var result = await _subject.GetVRPPublic();

        result.Should().BeEquivalentTo(expectedVrpPublic);
    }

    [Fact]
    public async Task GetVRPPublic_WhenHttpRequestFails_ThenThrowsSetupVrpPublicException()
    {
        var expectedException = new SetupVrpPublicException(_vrpPublicConfiguration.Url);
        var httpResponse = new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError };
        _httpWrapper.SendAsync(Arg.Is<HttpRequestMessage>(r => r.RequestUri.ToString() == _vrpPublicConfiguration.Url)).Returns(httpResponse);

        var act = () => _subject.GetVRPPublic();

        await act.Should().ThrowAsync<SetupVrpPublicException>(expectedException.Message);
    }
}
