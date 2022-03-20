using DownloadUpdate_GAR_DB_FIAS.Models;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.OutputService;

public interface IFileWriter
{
    Task WriteAsync(List<DocType> normativeDocsTypes, CancellationToken cancellationToken);
}
