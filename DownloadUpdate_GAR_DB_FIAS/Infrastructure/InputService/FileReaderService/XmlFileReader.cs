using DownloadUpdate_GAR_DB_FIAS.Configurations;
using DownloadUpdate_GAR_DB_FIAS.Models;
using Microsoft.Extensions.Options;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.Xml.Schema.XmlSeverityType;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.InputService.FileReaderService;

public sealed class XmlFileReader : IFileReader
{
    private readonly ReadOptions _options;

    public XmlFileReader(IOptions<ReadOptions> options)
    {
        _options = options.Value;
    }

    public async Task<List<DocType>> ReadAsync(FileInfo file, CancellationToken cancellationToken)
    {
        var fileSettings = new XmlReaderSettings();
        fileSettings.Schemas.Add("http://www.w3.org/2001/XMLSchema", _options.SchemaPath + _options.SchemaName);
        fileSettings.ValidationType = ValidationType.Schema;
        fileSettings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler!);
        using var fs = new FileStream(file.FullName, FileMode.Open);

        using var reader = XmlReader.Create(fs, fileSettings);

        var result = new List<DocType>();

        var serializer = new XmlSerializer(typeof(NDOCTYPES));
        var model = (NDOCTYPES)serializer.Deserialize(reader)!;

        return model.NDOCTYPE.Select(x => new DocType(x.ID, x.NAME, DateOnly.FromDateTime(x.STARTDATE), DateOnly.FromDateTime(x.ENDDATE))).ToList();

        static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            if (args.Severity is Warning or Error)
                throw new Exception(args.Message);
        }
    }
}
