using DownloadUpdate_GAR_DB_FIAS.Models;

namespace DownloadUpdate_GAR_DB_FIAS.Application;

public interface IOutputProvider
{
    Task OutputAsync(List<DocType> normativeDocsTypes, CancellationToken cancellationToken);
}
