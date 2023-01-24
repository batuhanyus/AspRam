var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/ram", () => $"{GC.GetTotalMemory(false) / 1024 / 1024} MB (managed)"
                         + Environment.NewLine +
                         $"System: {Environment.WorkingSet / 1024 / 1024} MB (total)");

app.Run();