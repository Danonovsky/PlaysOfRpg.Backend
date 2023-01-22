using Abstractions.Services;
using Infrastructure.Endpoints;
using Attribute = CharacterModule.Entities.Attribute;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpoints(typeof(Attribute),typeof(SwaggerEndpoint));

var app = builder.Build();
app.UseEndpoints();

app.Run();