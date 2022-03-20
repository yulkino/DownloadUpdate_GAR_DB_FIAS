using DownloadUpdate_GAR_DB_FIAS.Configurations;
using Microsoft.Extensions.Options;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileSearchService;

public sealed class FileSearcher : IFileSearcher
{
    private readonly ReadOptions _options;

    public FileSearcher(IOptions<ReadOptions> options)
    {
        _options = options.Value;
    }

    public Task<FileInfo> SearchAppropriateFileAsync(List<FileInfo> files, CancellationToken cancellationToken) 
        => Task.FromResult(files.FirstOrDefault(f => f.Name.Contains(_options.SchemaType)))!;
}
