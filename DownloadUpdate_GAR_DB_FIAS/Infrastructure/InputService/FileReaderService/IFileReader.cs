using DownloadUpdate_GAR_DB_FIAS.Models;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileReaderService;

public interface IFileReader
{
    Task<List<DocType>> ReadAsync(FileInfo file, CancellationToken cancellationToken);
}
