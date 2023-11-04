using System.Diagnostics.CodeAnalysis;

namespace QuestAppsDownloader.DTO.DTOs;

[ExcludeFromCodeCoverage]
public class Metadata
{
    public string GameName { get; set; }
    public string ReleaseName { get; set; }
    public string PackageName { get; set; }
    public string Version { get; set; }
    public DateTime LastUpdated { get; set; }
    public int Size { get; set; } 
}
