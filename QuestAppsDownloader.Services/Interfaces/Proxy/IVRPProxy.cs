using QuestAppsDownloader.DTO.DTOs;

namespace QuestAppsDownloader.Services.Interfaces.Proxy;

public interface IVRPProxy
{
    Task<VRPPublic> GetVRPPublic();
}
