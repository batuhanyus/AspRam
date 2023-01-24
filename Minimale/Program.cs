using System.Runtime;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://*:5000");


app.MapGet("/", () => "Hello World!");

app.MapGet("/ram", () => $"{GC.GetTotalMemory(false) / 1024 / 1024} MB (managed)"
                         + Environment.NewLine +
                         $"System: {Environment.WorkingSet / 1024 / 1024} MB (total)"
                         + Environment.NewLine +
                         $"IsServerGC: {GCSettings.IsServerGC}");

app.Run();