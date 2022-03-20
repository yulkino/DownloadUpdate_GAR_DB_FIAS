namespace DownloadUpdate_GAR_DB_FIAS.Configurations;

public sealed record NalogClientOptions
{
    public const string SectionName = "HttpClients:NalogClient";
    public string BaseUrl { get; init; }
    public string Download { get; init; }
}
