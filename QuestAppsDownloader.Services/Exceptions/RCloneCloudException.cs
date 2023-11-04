namespace QuestAppsDownloader.Services.Exceptions;

public class RCloneCloudException : Exception
{
    public RCloneCloudException(string cloudUrl) : base($"An error occured while calling the cloud server. Please check if {cloudUrl} is UP.")
    {
    }
}
