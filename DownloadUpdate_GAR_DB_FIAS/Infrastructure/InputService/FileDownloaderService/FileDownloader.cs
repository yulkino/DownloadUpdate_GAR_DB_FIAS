using DownloadUpdate_GAR_DB_FIAS.Configurations;
using Microsoft.Extensions.Options;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileDownloaderService;

public sealed class FileDownloader : IFileDownloader
{
    private readonly DownloadOptions _options;
    private readonly HttpClient _client;

    public FileDownloader(IOptions<DownloadOptions> options, HttpClient client)
    {
        _options = options.Value;
        _client = client;
    }

    public async Task<FileInfo> DownloadFileAsync(string filePath, CancellationToken cancellationToken)
    {
        using var response = await _client.GetAsync(filePath, cancellationToken);
        response.EnsureSuccessStatusCode();
        var directoryPath = _options.RelativePath;
        var subDirectoryPath = DateTime.Now.ToString("yyyy.MM.dd HH-mm-ss");
        var directoryInfo = Directory.CreateDirectory(directoryPath + "/" + subDirectoryPath);
        using var file = File.Create(directoryInfo.FullName + "/" + "download.zip");
        var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        await file.WriteAsync(bytes, cancellationToken);
        return new FileInfo(file.Name);
    }
}
