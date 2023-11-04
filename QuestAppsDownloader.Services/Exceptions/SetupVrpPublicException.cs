namespace QuestAppsDownloader.Services.Exceptions;

public class SetupVrpPublicException : Exception
{
    public SetupVrpPublicException(string vrpUrl) : base($"An error occured while calling the VRP website. Please check if {vrpUrl} is UP.")
    {
    }
}
