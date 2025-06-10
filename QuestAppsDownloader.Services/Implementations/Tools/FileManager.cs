using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using QuestAppsDownloader.Services.Interfaces.Tools;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace QuestAppsDownloader.Services.Implementations.Tools;

[ExcludeFromCodeCoverage]
public class FileManager : IFileManager
{
    public void CreateDirectory(string newDirectoryPath)
    {
        Directory.CreateDirectory(newDirectoryPath);
    }

    public void DeleteDirectory(string directoryPath)
    {
        Directory.Delete(directoryPath, true);
    }

    public bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    public void DeleteFile(string filePath)
    {
        File.Delete(filePath);
    }

    public void UnzipArchive(string filePath, string outputDirectory)
    {
        if (FileExists(filePath))
        {
            CreateDirectory(outputDirectory);
            ZipFile.ExtractToDirectory(filePath, outputDirectory, true);
        }
    }

    public void Unzip7zArchive(string filePath, string outputDirectory, string password = "")
    {
        if (FileExists(filePath))
        {
            CreateDirectory(outputDirectory);

            var archive = SevenZipArchive.Open(filePath, readerOptions: new ReaderOptions { Password = password });

            var reader = archive.ExtractAllEntries();
            while (reader.MoveToNextEntry())
            {
                try
                {
                    if (!reader.Entry.IsDirectory)
                        reader.WriteEntryToDirectory(outputDirectory, new ExtractionOptions { ExtractFullPath = true, Overwrite = true });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured when extracting some file : {ex.Message}");
                }
            }

            reader.Dispose();
            archive.Dispose();
        }
    }

    public string GetFilePath(string directoryPath, string fileName)
    {
        CreateDirectory(directoryPath);
        return Directory.GetFiles(directoryPath, fileName, SearchOption.AllDirectories).FirstOrDefault();
    }

    public IList<string> GetFilesInDirectory(string directoryPath, string pattern)
    {
        return Directory.GetFiles(directoryPath, pattern, SearchOption.AllDirectories);
    }
}
