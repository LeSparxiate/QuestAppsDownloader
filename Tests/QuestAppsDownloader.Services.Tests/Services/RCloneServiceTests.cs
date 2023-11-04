using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using QuestAppsDownloader.DTO.DTOs;
using QuestAppsDownloader.Services.Configurations;
using QuestAppsDownloader.Services.Exceptions;
using QuestAppsDownloader.Services.Implementations.Services;
using QuestAppsDownloader.Services.Interfaces.Tools;
using QuestAppsDownloader.Services.Interfaces.Wrappers;
using Xunit;

namespace QuestAppsDownloader.Services.Tests.Services;

public class RCloneServiceTests
{
    private const string RcloneArchivePath = "./rclone.zip";
    private const string RcloneFolderPath = "./rclone";
    private const string MetadataDirectoryPath = "./metadata";
    private const string MetadataArchive = "meta.7z";
    private const string DownloadsFolderPath = "./downloads";

    private static readonly IFixture Auto = new Fixture();

    private readonly IHttpWrapper _httpWrapper;
    private readonly IFileManager _fileManager;
    private readonly IRCloneWrapper _rcloneWrapper;
    private readonly MetadataConfiguration _metadataConfiguration;
    private readonly RcloneConfiguration _rcloneConfiguration;

    private readonly RCloneService _subject;

    public RCloneServiceTests()
    {
        _httpWrapper = Substitute.For<IHttpWrapper>();
        _fileManager = Substitute.For<IFileManager>();
        _rcloneWrapper = Substitute.For<IRCloneWrapper>();

        _metadataConfiguration = new MetadataConfiguration { MetadataCloudPath = Auto.Create<string>() };
        _rcloneConfiguration = new RcloneConfiguration { DownloadUrl = "http://google.com/" };

        _subject = new RCloneService(_httpWrapper, _fileManager, _rcloneWrapper, Options.Create(_metadataConfiguration), Options.Create(_rcloneConfiguration));
    }

    [Fact]
    public async Task SetupRclone_ThenDownloadExtractAndDeleteArchive()
    {
        await _subject.SetupRclone();

        await _httpWrapper.Received(1).DownloadFileAsync(_rcloneConfiguration.DownloadUrl, RcloneArchivePath);
        _fileManager.Received(1).UnzipArchive(RcloneArchivePath, RcloneFolderPath);
        _fileManager.Received(1).DeleteFile(RcloneArchivePath);
    }

    [Fact]
    public async Task SetupRclone_WhenDownloadFails_ThenThrowsRCloneSetupException()
    {
        var expectedException = new RCloneSetupException();
        _httpWrapper.DownloadFileAsync(_rcloneConfiguration.DownloadUrl, RcloneArchivePath).Throws(new Exception());

        var act = () => _subject.SetupRclone();

        await act.Should().ThrowAsync<RCloneSetupException>(expectedException.Message);
    }

    [Fact]
    public async Task SetupMetadata_ThenSyncAndExtractMetadata()
    {
        var password = Auto.Create<byte[]>();
        var vrpPublic = Auto.Build<VRPPublic>().With(v => v.Password, Convert.ToBase64String(password)).Create();

        await _subject.SetupMetadata(vrpPublic);

        _fileManager.Received(1).CreateDirectory(MetadataDirectoryPath);
        await _rcloneWrapper.Received(1).SyncAsync(vrpPublic.BaseUri, _metadataConfiguration.MetadataCloudPath, MetadataDirectoryPath);
        _fileManager.Received(1).Unzip7zArchive($"{MetadataDirectoryPath}/{MetadataArchive}", MetadataDirectoryPath, vrpPublic.GetDecodedPassword());
    }

    [Fact]
    public async Task SetupMetadata_WhenSyncFails_ThenThrowsRCloneCloudException()
    {
        var vrpPublic = Auto.Create<VRPPublic>();
        var expectedException = new RCloneCloudException(vrpPublic.BaseUri);
        _rcloneWrapper.SyncAsync(vrpPublic.BaseUri, _metadataConfiguration.MetadataCloudPath, MetadataDirectoryPath).Throws(expectedException);

        var act = () => _subject.SetupMetadata(vrpPublic);

        await act.Should().ThrowAsync<RCloneCloudException>(expectedException.Message);
    }

    [Fact]
    public async Task DownloadGame_ThenCopyAndExtractArchive()
    {
        var password = Auto.Create<byte[]>();
        var releaseName = "ReleaseName";
        var md5ReleaseName = "91c8b06bfb0bc63074f082d4b7408411";
        var destinationDirectory = $"{DownloadsFolderPath}/{md5ReleaseName}";
        var vrpPublic = Auto.Build<VRPPublic>().With(v => v.Password, Convert.ToBase64String(password)).Create();
        var files = Auto.CreateMany<string>().ToList();
        _fileManager.GetFilesInDirectory(destinationDirectory, "*.7z*").Returns(files);

        await _subject.DownloadGame(releaseName, vrpPublic);

        await _rcloneWrapper.Received(1).CopyAsync(vrpPublic.BaseUri, $":http:/{md5ReleaseName}/", destinationDirectory);
        _fileManager.Received(1).Unzip7zArchive(files.First(), destinationDirectory, vrpPublic.GetDecodedPassword());
    }

    [Fact]
    public async Task DownloadGame_WhenCopyFails_ThenThrowsRCloneCloudException()
    {
        var releaseName = "ReleaseName";
        var md5ReleaseName = "91c8b06bfb0bc63074f082d4b7408411";
        var destinationDirectory = $"{DownloadsFolderPath}/{md5ReleaseName}";
        var vrpPublic = Auto.Create<VRPPublic>();
        var expectedException = new RCloneCloudException(vrpPublic.BaseUri);
        _rcloneWrapper.CopyAsync(vrpPublic.BaseUri, $":http:/{md5ReleaseName}/", destinationDirectory).Throws(expectedException);

        var act = () => _subject.DownloadGame(releaseName, vrpPublic);

        await act.Should().ThrowAsync<RCloneCloudException>(expectedException.Message);
    }
}
