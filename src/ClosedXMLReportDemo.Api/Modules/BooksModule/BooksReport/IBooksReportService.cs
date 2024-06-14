namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksReport;

internal interface IBooksReportService
{
    public Task<byte[]> GetBooksReportAsync();
}