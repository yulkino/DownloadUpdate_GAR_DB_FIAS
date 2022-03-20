using DownloadUpdate_GAR_DB_FIAS.Configurations;
using DownloadUpdate_GAR_DB_FIAS.Models;
using Microsoft.Extensions.Options;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.Clients;

public sealed class NalogHttpClient : INalogHttpClient
{
    private readonly NalogClientOptions _options;
    private readonly HttpClient _client;

    public NalogHttpClient(IOptions<NalogClientOptions> options, HttpClient client)
    {
        _options = options.Value;
        _client = client;
    }

    public async Task<DownloadFileInfo> GetLastDownloadFileInfoAsync(CancellationToken cancellationToken)
    {
        using var response = await _client.GetAsync(_options.BaseUrl + _options.Download, cancellationToken);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<DownloadFileInfo>(cancellationToken: cancellationToken))!;
    }
}
