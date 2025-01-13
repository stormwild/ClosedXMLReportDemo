using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

Console.WriteLine("Creating Word document with a dropdown control...");

string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
string filePath = Path.Combine(desktopPath, "SimpleDropDownXX.docx");

try
{
    using WordprocessingDocument doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);

    // Add the main document part
    MainDocumentPart mainPart = doc.AddMainDocumentPart();
    mainPart.Document = new Document();
    Body body = mainPart.Document.AppendChild(new Body());

    // Add some regular text
    var paragraph1 = body.AppendChild(new Paragraph());
    var run1 = paragraph1.AppendChild(new Run());
    run1.AppendChild(new Text("Here's a simple document with a dropdown list below:"));

    // Add some spacing
    body.AppendChild(new Paragraph());

    // Create the dropdown control
    var dropDownControl = new SdtBlock(
        new SdtProperties(
            new SdtAlias() { Val = "SimpleDropDown" },
            new Tag() { Val = "DropDown1" },
            new SdtId() { Val = 1 },
            new SdtContentDropDownList(
                new ListItem() { DisplayText = "Option 1", Value = "1" },
                new ListItem() { DisplayText = "Option 2", Value = "2" },
                new ListItem() { DisplayText = "Option 3", Value = "3" }
            )
        ),
        new SdtContentBlock(
            new Paragraph(
                new Run(
                    new Text("Select an option")
                )
            )
        )
    );

    body.AppendChild(dropDownControl);

    mainPart.Document.Save();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

Console.WriteLine($"Document created at: {filePath}");
Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();