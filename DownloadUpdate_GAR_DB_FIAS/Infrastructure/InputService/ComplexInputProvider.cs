using DownloadUpdate_GAR_DB_FIAS.Application;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.DownloadFileInfoProviderService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileDownloaderService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileReaderService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileSearchService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.UnzipperService;
using DownloadUpdate_GAR_DB_FIAS.Models;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService;

public sealed class ComplexInputProvider : IInputProvider
{
    private readonly IDownloadFileInfoProvider _downloadFileInfoProvider;
    private readonly IFileDownloader _fileDownloader;
    private readonly IUnzipper _unzipper;
    private readonly IFileSearcher _fileSearcher;
    private readonly IFileReader _fileReader;

    public ComplexInputProvider(IDownloadFileInfoProvider downloadFileInfoProvider, IFileDownloader fileDownloader, 
        IUnzipper unzipper, IFileSearcher fileSearcher, IFileReader fileReader)
    {
        _downloadFileInfoProvider = downloadFileInfoProvider;
        _fileDownloader = fileDownloader;
        _unzipper = unzipper;
        _fileSearcher = fileSearcher;
        _fileReader = fileReader;
    }

    public async Task<List<DocType>> GetInputAsync(CancellationToken cancellationToken)
    {
        var downloadFileInfo = await _downloadFileInfoProvider.GetDownloadFileInfoAsync(cancellationToken);
        var zip = await _fileDownloader.DownloadFileAsync(downloadFileInfo.GarXMLDeltaURL, cancellationToken);
        var unzip = await _unzipper.UnzipAsync(zip, cancellationToken);
        var file = await _fileSearcher.SearchAppropriateFileAsync(unzip, cancellationToken);
        return await _fileReader.ReadAsync(file, cancellationToken);
    }
}
