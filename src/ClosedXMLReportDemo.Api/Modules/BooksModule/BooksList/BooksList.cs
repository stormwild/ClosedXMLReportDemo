namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksList;

public static class BooksList
{
    public static void AddBooksList(this IServiceCollection services)
    {
        services.AddScoped<IBooksListService, BooksListService>();
    }

    public static RouteGroupBuilder MapBooksList(this RouteGroupBuilder app)
    {
        app.MapGet("/books", HandleAsync)
        .WithOpenApi(operation => new(operation)
        {
            Summary = "BooksList",
            Tags = [new() { Name = "BooksList" }]
        });

        return app;
    }

    private static async Task<IResult> HandleAsync(IBooksListService booksListService)
    {
        var books = await booksListService.GetBooksListAsync();
        return Results.Ok(books);
    }
}
