using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestAppsDownloader.Controllers;
using QuestAppsDownloader.Services.Configurations;
using QuestAppsDownloader.Services.Implementations.Proxy;
using QuestAppsDownloader.Services.Implementations.Services;
using QuestAppsDownloader.Services.Implementations.Tools;
using QuestAppsDownloader.Services.Implementations.Wrappers;
using QuestAppsDownloader.Services.Interfaces.Proxy;
using QuestAppsDownloader.Services.Interfaces.Services;
using QuestAppsDownloader.Services.Interfaces.Tools;
using QuestAppsDownloader.Services.Interfaces.Wrappers;

namespace QuestAppsDownloader.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection DependencyInjections(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton(_ => config)
            .Configure<VRPPublicConfiguration>(config.GetSection("VRPPublicConfiguration"))
            .Configure<MetadataConfiguration>(config.GetSection("MetadataConfiguration"))
            .Configure<RcloneConfiguration>(config.GetSection("RcloneConfiguration"))
            .AddScoped<MainWindowController>()
            .AddScoped<IRCloneService, RCloneService>()
            .AddScoped<IVRPProxy, VRPProxy>()
            .AddScoped<IFileManager, FileManager>()
            .AddScoped<HttpClient>()
            .AddScoped<IHttpWrapper, HttpWrapper>()
            .AddScoped<IRCloneWrapper, RCloneWrapper>();

        return services;
    }
}
