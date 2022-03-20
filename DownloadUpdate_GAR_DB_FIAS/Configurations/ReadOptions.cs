namespace DownloadUpdate_GAR_DB_FIAS.Configurations;

public sealed record ReadOptions
{
    public const string SectionName = "ConvertOptions";
    public string SchemaPath { get; init; }
    public string SchemaType { get; init; }
    public string SchemaName { get; init; }
}
