namespace ClosedXMLReportDemo.Api.Modules.BooksModule;

public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
