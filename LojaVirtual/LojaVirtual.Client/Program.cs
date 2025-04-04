using LojaVirtual.Client.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();

app.ConfigurePipeline();

app.Run();
