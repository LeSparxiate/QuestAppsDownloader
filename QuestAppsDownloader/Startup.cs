using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestAppsDownloader.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace QuestAppsDownloader;

[ExcludeFromCodeCoverage]
public class Startup
{
    public static IServiceCollection PerformInjections()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables();
        IConfiguration config = builder.Build();

        var services = new ServiceCollection().DependencyInjections(config);

        return services;
    }
}
