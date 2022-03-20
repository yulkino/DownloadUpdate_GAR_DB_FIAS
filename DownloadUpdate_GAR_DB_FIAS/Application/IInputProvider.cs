using DownloadUpdate_GAR_DB_FIAS.Models;

namespace DownloadUpdate_GAR_DB_FIAS.Application;

public interface IInputProvider
{
    Task<List<DocType>> GetInputAsync(CancellationToken cancellationToken);
}
