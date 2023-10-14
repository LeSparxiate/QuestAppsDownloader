using System.Text;

namespace QuestAppsDownloader.DTO.DTOs;

public class VRPPublic
{
    public string BaseUri { get; set; }
    public string Password { get; set; }

    public string GetDecodedPassword()
        => string.IsNullOrEmpty(Password) ? string.Empty : Encoding.UTF8.GetString(Convert.FromBase64String(Password));
}
