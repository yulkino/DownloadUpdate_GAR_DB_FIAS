using DownloadUpdate_GAR_DB_FIAS.Models;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.DownloadFileInfoProviderService;

public interface IDownloadFileInfoProvider
{
    Task<DownloadFileInfo> GetDownloadFileInfoAsync(CancellationToken cancellationToken);
}
