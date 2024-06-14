using ClosedXMLReportDemo.Api.Modules.BooksModule.BooksList;
using ClosedXMLReportDemo.Api.Modules.BooksModule.BooksReport;

namespace ClosedXMLReportDemo.Api;

public static class ServiceCollectionExtensions
{
    public static void AddModules(this IServiceCollection services)
    {
        services.AddBooksList();
        services.AddBooksReport();
    }
}
