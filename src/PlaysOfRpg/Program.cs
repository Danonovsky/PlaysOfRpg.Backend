using Abstractions.Services;
using Attribute = CharacterModule.Entities.Attribute;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(Attribute));

var app = builder.Build();
app.UseEndpointDefinitions();
app.MapGet("/", () => "Plays of Rpg!");

app.Run();