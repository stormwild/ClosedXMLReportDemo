# Demo Using ClosedXML.Report

This is a simple demo to show how to use ClosedXML.Report to generate Excel files from a template.

## ClosedXML

[ClosedXML - Simple Spreadsheet Creation](https://closedxml.io/)

[ClosedXML — ClosedXML 0.102.0 documentation](https://docs.closedxml.io/en/latest/)

[ClosedXML/ClosedXML: ClosedXML is a .NET library for reading, manipulating and writing Excel 2007+ (.xlsx, .xlsm) files. It aims to provide an intuitive and user-friendly interface to dealing with the underlying OpenXML API.](https://github.com/ClosedXML/ClosedXML)

## ClosedXML.Report

[ClosedXML.Report | Documentation for ClosedXML.Report](https://closedxml.io/ClosedXML.Report/)

## Steps

In the Template/Book.xlsx file, we have a sheet named "Books" with the following content:

| Id          | Title          |
|-------------|----------------|
| {{item.Id}} | {{item.Title}} |

In Formulas > Name Manager, we have defined a named range called "BookList" which refers to the range: `=Books!$A$2:B3`

Our list of books is mapped to the named range "BookList" in the template.

```csharp
        var books = await _booksListService.GetBooksListAsync();

        var template = new XLTemplate(@"Templates\Books.xlsx");
        template.AddVariable("BookList", books);
        template.Generate();
```

The BooksReport file that is returned

```csharp
        var excelFile = await booksReportService.GetBooksReportAsync();
        return Results.File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BooksReport.xlsx");
```

Outputs

| Id | Title  |
|----|--------|
| 1  | Book 1 |
| 2  | Book 2 |
| 3  | Book 3 |
| 4  | Book 4 |
