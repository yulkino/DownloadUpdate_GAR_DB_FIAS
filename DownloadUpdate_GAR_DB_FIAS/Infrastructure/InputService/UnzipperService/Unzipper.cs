using System.IO.Compression;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.UnzipperService;

public sealed class Unzipper : IUnzipper
{
    public Task<List<FileInfo>> UnzipAsync(FileInfo zip, CancellationToken cancellationToken)
    {
        var directory = zip.Directory!;
        ZipFile.ExtractToDirectory(zip.FullName, directory.FullName);
        return Task.FromResult(directory.GetFiles().ToList());
    }
}
