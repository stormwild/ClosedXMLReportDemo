namespace ClosedXMLReportDemo.Api.Modules.BooksModule.BooksReport;

public static class BooksReport
{
    public static void AddBooksReport(this IServiceCollection services)
    {
        services.AddScoped<IBooksReportService, BooksReportService>();
    }

    public static void MapBooksReport(this WebApplication app)
    {
        app.MapGet("/books/report", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IBooksReportService booksReportService)
    {
        var excelFile = await booksReportService.GetBooksReportAsync();
        return Results.File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BooksReport.xlsx");
    }
}
