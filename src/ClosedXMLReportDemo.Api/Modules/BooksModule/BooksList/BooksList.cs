namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksList;

public static class BooksList
{
    public static void AddBooksList(this IServiceCollection services)
    {
        services.AddScoped<IBooksListService, BooksListService>();
    }

    public static void MapBooksList(this WebApplication app)
    {
        app.MapGet("/books", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IBooksListService booksListService)
    {
        var books = await booksListService.GetBooksListAsync();
        return Results.Ok(books);
    }
}
