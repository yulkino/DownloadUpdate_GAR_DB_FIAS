namespace DownloadUpdate_GAR_DB_FIAS.Configurations;

public sealed record DownloadOptions
{
    public const string SectionName = "DownloadOptions";
    public string RelativePath { get; init; }
}