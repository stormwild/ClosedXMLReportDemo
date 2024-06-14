using ClosedXML.Report;

using ClosedXMLReportDemo.Api.Modules.BooksModule.BooksList;

namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksReport;

internal class BooksReportService : IBooksReportService
{
    private readonly IBooksListService _booksListService;

    public BooksReportService(IBooksListService booksListService)
    {
        _booksListService = booksListService;
    }
    public async Task<byte[]> GetBooksReportAsync()
    {
        var books = await _booksListService.GetBooksListAsync();

        var template = new XLTemplate(@"Templates\Books.xlsx");
        template.AddVariable("BookList", books);
        template.Generate();

        // If we want to save the file to disk and return the file bytes
        // var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BooksReport.xlsx");
        // template.SaveAs(reportPath);
        // return await File.ReadAllBytesAsync(reportPath);

        using var stream = new MemoryStream();
        template.SaveAs(stream);
        return stream.ToArray();
    }
}
