using DownloadUpdate_GAR_DB_FIAS.Application;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.Clients;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.DownloadFileInfoProviderService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileDownloaderService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileReaderService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileSearchService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.UnzipperService;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure.OutputService;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddComplexInput(this IServiceCollection services)
    {
        return services.AddSingleton<IInputProvider, ComplexInputProvider>()
            .AddSingleton<IDownloadFileInfoProvider, DownloadFileInfoProvider>()
            .AddSingleton<IFileDownloader, FileDownloader>()
            .AddSingleton<IUnzipper, Unzipper>()
            .AddSingleton<IFileSearcher, FileSearcher>()
            .AddSingleton<IFileReader, XmlFileReader>()
            .AddHttpClient()
            .AddSingleton<INalogHttpClient, NalogHttpClient>();
    }

    public static IServiceCollection AddFileOutput(this IServiceCollection services) 
        => services.AddSingleton<IOutputProvider, FileOutputProvider>()
            .AddSingleton<IFileWriter, CsvFileWriter>();
}
