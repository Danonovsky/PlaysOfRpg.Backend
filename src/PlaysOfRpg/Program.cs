using System.Reflection;
using Abstractions.Services;

var builder = WebApplication.CreateBuilder(args);
LoadAssemblies();
var type = typeof(IEndpoint);
var types = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(_ => _.GetExportedTypes())
    .Where(_ => _.IsAssignableTo(type) && _.IsInterface is false)
    .ToArray();
builder.Services.AddEndpoints(types);

var app = builder.Build();
app.UseEndpoints();

app.Run();
void LoadAssemblies()
{
    var directory = new DirectoryInfo(AppContext.BaseDirectory);
    if (!directory.Exists) return;
    var dllFiles = directory.GetFiles("*.dll");
    foreach (var fileInfo in dllFiles)
    {
        Assembly.LoadFrom(fileInfo.FullName);
    }
}