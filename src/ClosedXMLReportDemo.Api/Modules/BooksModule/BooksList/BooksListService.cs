namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksList;

public class BooksListService : IBooksListService
{
    public async Task<IEnumerable<Book>> GetBooksListAsync()
    {
        var books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Book { Id = 2, Title = "Book 2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Book { Id = 3, Title = "Book 3", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new Book { Id = 4, Title = "Book 4", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
        };

        return await Task.FromResult(books.AsEnumerable()).ConfigureAwait(false);
    }
}
