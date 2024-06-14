using ClosedXMLReportDemo.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddModules();

var app = builder.Build();

app.MapModules();

app.Run();
