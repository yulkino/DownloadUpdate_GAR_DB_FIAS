using DownloadUpdate_GAR_DB_FIAS.Models;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.Clients;

public interface INalogHttpClient
{
    Task<DownloadFileInfo> GetLastDownloadFileInfoAsync(CancellationToken cancellationToken);
}
