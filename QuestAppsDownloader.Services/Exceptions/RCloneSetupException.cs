namespace QuestAppsDownloader.Services.Exceptions;

public class RCloneSetupException : Exception
{
    public RCloneSetupException() : base("An error occured while downloading Rclone. Please try again later.")
    {
    }
}
