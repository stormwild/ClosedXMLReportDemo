namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksList;

public class BooksListService : IBooksListService
{
    public async Task<IEnumerable<Book>> GetBooksListAsync()
    {
        var books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1" },
            new Book { Id = 2, Title = "Book 2" },
            new Book { Id = 3, Title = "Book 3" },
            new Book { Id = 4, Title = "Book 4" },
        };

        return await Task.FromResult(books.AsEnumerable()).ConfigureAwait(false);
    }
}
