using Microsoft.Extensions.DependencyInjection;
using QuestAppsDownloader.Controllers;
using System.Diagnostics.CodeAnalysis;

namespace QuestAppsDownloader;

[ExcludeFromCodeCoverage]
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var serviceProvider = CreateServiceProvider();

        Application.Run(new MainWindow(serviceProvider.GetService<MainWindowController>()));
    }

    private static ServiceProvider CreateServiceProvider()
    {
        return Startup.PerformInjections().BuildServiceProvider();
    }
}