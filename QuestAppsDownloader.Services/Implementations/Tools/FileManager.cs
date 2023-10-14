using System.IO.Compression;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace QuestAppsDownloader.Services.Implementations.Tools;

public class FileManager
{
    public static void CreateDirectory(string newDirectoryPath)
    {
        Directory.CreateDirectory(newDirectoryPath);
    }

    public static void DeleteDirectory(string directoryPath)
    {
        Directory.Delete(directoryPath, true);
    }

    public static bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    public static void DeleteFile(string filePath)
    {
        File.Delete(filePath);
    }

    public static void UnzipArchive(string filePath, string outputDirectory)
    {
        if (FileExists(filePath))
        {
            CreateDirectory(outputDirectory);
            ZipFile.ExtractToDirectory(filePath, outputDirectory, true);
        }
    }

    public static void Unzip7zArchive(string filePath, string outputDirectory, string password = "")
    {
        if (FileExists(filePath))
        {
            CreateDirectory(outputDirectory);

            var archive = SevenZipArchive.Open(filePath, readerOptions: new SharpCompress.Readers.ReaderOptions { Password = password });

            var reader = archive.ExtractAllEntries();
            while (reader.MoveToNextEntry())
            {
                if (!reader.Entry.IsDirectory)
                    reader.WriteEntryToDirectory(outputDirectory, new ExtractionOptions { ExtractFullPath = true, Overwrite = true });
            }

            reader.Dispose();
            archive.Dispose();
        }
    }

    public static string GetFilePath(string directoryPath, string fileName)
    {
        return Directory.GetFiles(directoryPath, fileName, SearchOption.AllDirectories).FirstOrDefault();
    }

    public static IList<string> GetFilesInDirectory(string directoryPath, string pattern)
    {
        return Directory.GetFiles(directoryPath, pattern, SearchOption.AllDirectories);
    }
}
