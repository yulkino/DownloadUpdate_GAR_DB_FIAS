namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileDownloaderService;

public interface IFileDownloader
{
    Task<FileInfo> DownloadFileAsync(string filePath, CancellationToken cancellationToken);
}
