namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileSearchService;

public interface IFileSearcher
{
    Task<FileInfo> SearchAppropriateFileAsync(List<FileInfo> file, CancellationToken cancellationToken);
}

