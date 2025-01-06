// See https://aka.ms/new-console-template for more information
using ClosedXML.Excel;

Console.WriteLine("Hello, World!");

using (var workbook = new XLWorkbook())
{
    CreateSalesSheet(workbook);
    CreateEmployeeSheet(workbook);
    CreateInventorySheet(workbook);

    workbook.SaveAs("FormulaExamples.xlsx");
}


static void CreateSalesSheet(IXLWorkbook workbook)
{
    var worksheet = workbook.AddWorksheet("Sales Analysis");

    // Add headers
    worksheet.Cell("A1").Value = "Month";
    worksheet.Cell("B1").Value = "Region";
    worksheet.Cell("C1").Value = "Sales";
    worksheet.Cell("D1").Value = "Target";
    worksheet.Cell("E1").Value = "Achievement%";
    worksheet.Cell("F1").Value = "Status";

    // Add sample data
    var months = Enumerable.Range(1, 12)
        .SelectMany(month => new[] { "North", "South", "East", "West" }
        .Select(region => new
        {
            Month = new DateTime(2024, month, 1).ToString("MMM"),
            Region = region,
            Sales = Random.Shared.Next(10000, 50000),
            Target = 30000
        }));

    int row = 2;
    foreach (var data in months)
    {
        worksheet.Cell(row, 1).Value = data.Month;
        worksheet.Cell(row, 2).Value = data.Region;
        worksheet.Cell(row, 3).Value = data.Sales;
        worksheet.Cell(row, 4).Value = data.Target;

        // Achievement% formula using ROUND
        worksheet.Cell(row, 5).FormulaA1 = $"=ROUND(C{row}/D{row}*100,1)";

        // Status using IF
        worksheet.Cell(row, 6).FormulaA1 = $"=IF(E{row}>=100,\"Achieved\",\"Not Achieved\")";

        row++;
    }

    // Add summary section
    worksheet.Cell("H1").Value = "Summary";
    worksheet.Cell("H2").Value = "Total Sales";
    worksheet.Cell("H3").Value = "Average Sales";
    worksheet.Cell("H4").Value = "Min Sales";
    worksheet.Cell("H5").Value = "Max Sales";
    worksheet.Cell("H6").Value = "Regions Above Target";

    // Add formulas
    worksheet.Cell("I2").FormulaA1 = "=SUM(C2:C49)";  // SUM example
    worksheet.Cell("I3").FormulaA1 = "=AVERAGE(C2:C49)";  // AVERAGE example
    worksheet.Cell("I4").FormulaA1 = "=MIN(C2:C49)";  // MIN example
    worksheet.Cell("I5").FormulaA1 = "=MAX(C2:C49)";  // MAX example
    worksheet.Cell("I6").FormulaA1 = "=COUNTIF(E2:E49,\">100\")";  // COUNTIF example

    // Format headers
    worksheet.Range("A1:F1").Style.Fill.BackgroundColor = XLColor.Green;
    worksheet.Range("A1:F1").Style.Font.Bold = true;
    worksheet.Range("H1:I1").Style.Font.Bold = true;
}

static void CreateEmployeeSheet(IXLWorkbook workbook)
{
    var worksheet = workbook.AddWorksheet("Employee Performance");

    // Add headers
    worksheet.Cell("A1").Value = "Employee ID";
    worksheet.Cell("B1").Value = "First Name";
    worksheet.Cell("C1").Value = "Last Name";
    worksheet.Cell("D1").Value = "Department";
    worksheet.Cell("E1").Value = "Performance Score";
    worksheet.Cell("F1").Value = "Full Name";
    worksheet.Cell("G1").Value = "Bonus Tier";
    worksheet.Cell("H1").Value = "Bonus Amount";

    // Sample data
    var employees = new[]
    {
            new { ID = "EMP001", First = "John", Last = "Doe", Dept = "Sales", Score = 4.5 },
            new { ID = "EMP002", First = "Jane", Last = "Smith", Dept = "Marketing", Score = 3.8 },
            new { ID = "EMP003", First = "Bob", Last = "Johnson", Dept = "IT", Score = 4.2 },
            // Add more employees...
        };

    int row = 2;
    foreach (var emp in employees)
    {
        worksheet.Cell(row, 1).Value = emp.ID;
        worksheet.Cell(row, 2).Value = emp.First;
        worksheet.Cell(row, 3).Value = emp.Last;
        worksheet.Cell(row, 4).Value = emp.Dept;
        worksheet.Cell(row, 5).Value = emp.Score;

        // CONCATENATE example
        worksheet.Cell(row, 6).FormulaA1 = $"=CONCATENATE(B{row},\" \",C{row})";

        // Nested IF example for Bonus Tier
        worksheet.Cell(row, 7).FormulaA1 =
            $"=IF(E{row}>=4.5,\"Platinum\",IF(E{row}>=4,\"Gold\",IF(E{row}>=3.5,\"Silver\",\"Bronze\")))";

        // VLOOKUP example with bonus calculation
        worksheet.Cell(row, 8).FormulaA1 =
            $"=IF(G{row}=\"Platinum\",50000,IF(G{row}=\"Gold\",30000,IF(G{row}=\"Silver\",20000,10000)))";

        row++;
    }

    // Format headers
    worksheet.Range("A1:H1").Style.Fill.BackgroundColor = XLColor.Green;
    worksheet.Range("A1:H1").Style.Font.Bold = true;
}

static void CreateInventorySheet(IXLWorkbook workbook)
{
    var worksheet = workbook.AddWorksheet("Inventory");

    // Add headers
    worksheet.Cell("A1").Value = "Product Code";
    worksheet.Cell("B1").Value = "Product Name";
    worksheet.Cell("C1").Value = "Category";
    worksheet.Cell("D1").Value = "Current Stock";
    worksheet.Cell("E1").Value = "Reorder Point";
    worksheet.Cell("F1").Value = "Stock Status";
    worksheet.Cell("G1").Value = "Category Code";

    // Sample data
    var products = new[]
    {
            new { Code = "TECH-001", Name = "Laptop", Category = "Electronics", Stock = 25, Reorder = 20 },
            new { Code = "TECH-002", Name = "Mouse", Category = "Electronics", Stock = 15, Reorder = 30 },
            new { Code = "OFF-001", Name = "Desk", Category = "Furniture", Stock = 10, Reorder = 5 },
            // Add more products...
        };

    int row = 2;
    foreach (var prod in products)
    {
        worksheet.Cell(row, 1).Value = prod.Code;
        worksheet.Cell(row, 2).Value = prod.Name;
        worksheet.Cell(row, 3).Value = prod.Category;
        worksheet.Cell(row, 4).Value = prod.Stock;
        worksheet.Cell(row, 5).Value = prod.Reorder;

        // LEFT function example for category code
        worksheet.Cell(row, 7).FormulaA1 = $"=LEFT(A{row},4)";

        // Logical operators example for stock status
        worksheet.Cell(row, 6).FormulaA1 =
            $"=IF(AND(D{row}>E{row},D{row}<E{row}*2),\"Order Soon\",IF(D{row}<=E{row},\"Reorder Now\",\"OK\"))";

        row++;
    }

    // Format headers
    worksheet.Range("A1:G1").Style.Fill.BackgroundColor = XLColor.Green;
    worksheet.Range("A1:G1").Style.Font.Bold = true;
}