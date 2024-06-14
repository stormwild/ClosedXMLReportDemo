namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksList;

public interface IBooksListService
{
    Task<IEnumerable<Book>> GetBooksListAsync();
}