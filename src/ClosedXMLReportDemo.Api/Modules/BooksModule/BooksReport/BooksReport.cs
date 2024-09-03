namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksReport;

public static class BooksReport
{
    public static void AddBooksReport(this IServiceCollection services)
    {
        services.AddScoped<IBooksReportService, BooksReportService>();
    }

    public static RouteGroupBuilder MapBooksReport(this RouteGroupBuilder app)
    {
        app.MapGet("/books/report", HandleAsync)
           .WithOpenApi(operation => new(operation)
           {
               Summary = "BooksReport",
               Tags = [new() { Name = "BooksReport" }]
           });

        return app;
    }

    private static async Task<IResult> HandleAsync(IBooksReportService booksReportService)
    {
        var excelFile = await booksReportService.GetBooksReportAsync();
        return Results.File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BooksReport.xlsx");
    }
}
