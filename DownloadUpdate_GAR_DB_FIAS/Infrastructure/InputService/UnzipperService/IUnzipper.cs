namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.UnzipperService;

public interface IUnzipper
{
    Task<List<FileInfo>> UnzipAsync(FileInfo zip, CancellationToken cancellationToken);
}
