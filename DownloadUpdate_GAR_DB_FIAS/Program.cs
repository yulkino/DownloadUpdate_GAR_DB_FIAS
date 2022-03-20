using DownloadUpdate_GAR_DB_FIAS.Application;
using DownloadUpdate_GAR_DB_FIAS.Configurations;
using DownloadUpdate_GAR_DB_FIAS.Infrastructure;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices(services =>
{
    services.AddSingleton<Main>()
        .AddComplexInput()
        .AddFileOutput();

    services.Configure<NalogClientOptions>(config.GetSection(NalogClientOptions.SectionName))
        .Configure<DownloadOptions>(config.GetSection(DownloadOptions.SectionName))
        .Configure<ReadOptions>(config.GetSection(ReadOptions.SectionName))
        .Configure<OutputOptions>(config.GetSection(OutputOptions.SectionName));
});
var host = builder.Build();

var app = ActivatorUtilities.CreateInstance<Main>(host.Services);

using var clt = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) => clt.Cancel();

await app.StartAsync(clt.Token);
