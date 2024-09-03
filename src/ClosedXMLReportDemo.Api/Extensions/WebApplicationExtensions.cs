using ClosedXMLReportDemo.Api.Modules.BooksModule.BooksList;
using ClosedXMLReportDemo.Api.Modules.BooksModule.BooksReport;

namespace ClosedXMLReportDemo.Api;

public static class WebApplicationExtensions
{
    public static void MapModules(this WebApplication app)
    {
        app.MapGroup("/api")
            .MapBooksList()
            .MapBooksReport();
    }
}
