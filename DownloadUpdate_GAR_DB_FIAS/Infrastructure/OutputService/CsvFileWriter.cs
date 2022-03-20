using DownloadUpdate_GAR_DB_FIAS.Configurations;
using DownloadUpdate_GAR_DB_FIAS.Models;
using Microsoft.Extensions.Options;
using System.Text;

namespace DownloadUpdate_GAR_DB_FIAS.Infrastructure.OutputService;

public class CsvFileWriter : IFileWriter
{
    private OutputOptions _options;

    public CsvFileWriter(IOptions<OutputOptions> options)
    {
        _options = options.Value;
    }

    public Task WriteAsync(List<DocType> normativeDocsTypes, CancellationToken cancellationToken)
    {
        var doctype = normativeDocsTypes.First();
        var names = new[] { nameof(doctype.Id), nameof(doctype.Name), nameof(doctype.StartDate), nameof(doctype.EndDate) };
        var directory = Directory.CreateDirectory(_options.OutputTo);
        using var writer = new StreamWriter(directory.FullName + nameof(DocType) +  DateTime.Now.ToString(" yyyy.MM.dd HH-mm-ss") + ".CSV", false, Encoding.UTF8);
        writer.WriteLine(string.Join(";", names));
        foreach(var element in normativeDocsTypes)
        {
            var line = new object[] { element.Id, element.Name, element.StartDate, element.EndDate };
            writer.WriteLine(string.Join(";", line));
        }
        return Task.CompletedTask;
    }
}
