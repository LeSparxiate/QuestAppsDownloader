using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestAppsDownloader.Controllers;
using QuestAppsDownloader.Services.Configurations;
using QuestAppsDownloader.Services.Implementations.Proxy;
using QuestAppsDownloader.Services.Implementations.Services;
using QuestAppsDownloader.Services.Implementations.Wrappers;
using QuestAppsDownloader.Services.Interfaces.Proxy;
using QuestAppsDownloader.Services.Interfaces.Services;
using QuestAppsDownloader.Services.Interfaces.Wrappers;

namespace QuestAppsDownloader;

public class Startup
{
    public static IServiceCollection PerformInjections()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables();
        IConfiguration config = builder.Build();

        var services = new ServiceCollection().AddSingleton(_ => config)
            .Configure<VRPPublicConfiguration>(config.GetSection("VRPPublicConfiguration"))
            .Configure<MetadataConfiguration>(config.GetSection("MetadataConfiguration"))
            .Configure<RcloneConfiguration>(config.GetSection("RcloneConfiguration"))
            .AddScoped<MainWindowController>()
            .AddScoped<IRcloneService, RcloneService>()
            .AddScoped<IVRPProxy, VRPProxy>()
            .AddScoped<HttpClient>()
            .AddScoped<IHttpWrapper, HttpWrapper>();

        return services;
    }
}
