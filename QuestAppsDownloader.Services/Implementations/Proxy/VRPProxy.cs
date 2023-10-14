using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuestAppsDownloader.DTO.DTOs;
using QuestAppsDownloader.Services.Configurations;
using QuestAppsDownloader.Services.Interfaces.Proxy;
using QuestAppsDownloader.Services.Interfaces.Wrappers;

namespace QuestAppsDownloader.Services.Implementations.Proxy;

public class VRPProxy : IVRPProxy
{
    private readonly IHttpWrapper _httpWrapper;
    private readonly VRPPublicConfiguration _vrpPublicConfiguration;

    public VRPProxy(IHttpWrapper httpWrapper, IOptions<VRPPublicConfiguration> vrpPublicConfiguration)
    {
        _httpWrapper = httpWrapper;
        _vrpPublicConfiguration = vrpPublicConfiguration.Value;
    }

    public async Task<VRPPublic> GetVRPPublic()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _vrpPublicConfiguration.Url);
        var response = await _httpWrapper.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return JsonConvert.DeserializeObject<VRPPublic>(await response.Content.ReadAsStringAsync());
    }
}
