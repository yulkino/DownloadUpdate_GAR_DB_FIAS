using DownloadUpdate_GAR_DB_FIAS.Application;
using DownloadUpdate_GAR_DB_FIAS.Configurations;
using DownloadUpdate_GAR_DB_FIAS.Models;
using Microsoft.Extensions.Options;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.OutputService;

public class FileOutputProvider : IOutputProvider
{
    private readonly IFileWriter _fileWriter;

    public FileOutputProvider(IFileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public Task OutputAsync(List<DocType> normativeDocsTypes, CancellationToken cancellationToken) 
        => _fileWriter.WriteAsync(normativeDocsTypes, cancellationToken);
}
