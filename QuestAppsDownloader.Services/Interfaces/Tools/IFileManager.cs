namespace QuestAppsDownloader.Services.Interfaces.Tools;

public interface IFileManager
{
    void CreateDirectory(string newDirectoryPath);
    void DeleteDirectory(string directoryPath);
    bool FileExists(string filePath);
    void DeleteFile(string filePath);
    void UnzipArchive(string filePath, string outputDirectory);
    void Unzip7zArchive(string filePath, string outputDirectory, string password = "");
    string GetFilePath(string directoryPath, string fileName);
    IList<string> GetFilesInDirectory(string directoryPath, string pattern);
}
