using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.Clients;
using DownloadUpdate_GAR_DB_FIAS.Models;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.DownloadFileInfoProviderService;

public sealed class DownloadFileInfoProvider : IDownloadFileInfoProvider
{
    private readonly INalogHttpClient _client;

    public DownloadFileInfoProvider(INalogHttpClient client)
    {
        _client = client;
    }

    public Task<DownloadFileInfo> GetDownloadFileInfoAsync(CancellationToken cancellationToken) 
        => _client.GetLastDownloadFileInfoAsync(cancellationToken);
}
