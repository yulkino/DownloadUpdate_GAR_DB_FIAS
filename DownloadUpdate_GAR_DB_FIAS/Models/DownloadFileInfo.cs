namespace DownloadUpdate_GAR_DB_FIAS.Models;

public sealed record DownloadFileInfo
   (int VersionId,
    string TextVersion,
    string FiasCompleteDbfUrl,
    string FiasCompleteXmlUrl,
    string FiasDeltaDbfUrl,
    string FiasDeltaXmlUrl,
    string Kladr4ArjUrl,
    string Kladr47ZUrl,
    string GarXMLFullURL,
    string GarXMLDeltaURL,
    string Date);
