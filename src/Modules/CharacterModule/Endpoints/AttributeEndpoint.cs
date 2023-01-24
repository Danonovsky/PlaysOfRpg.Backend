using Abstractions.Services;
using CharacterModule.DAL;
using CharacterModule.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Attribute = CharacterModule.DAL.Entities.Attribute;

namespace CharacterModule.Endpoints;

public class AttributeEndpoint : IEndpoint
{
    private const string Route = "api/attribute";

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet(Route, async (IAttributeRepository repo) => await repo.GetAllAsync());
        app.MapGet($"{Route}/{{id:guid}}", async (IAttributeRepository repo, Guid id) => await repo.GetByIdAsync(id));
        app.MapPost($"{Route}", async (IAttributeRepository repo, Attribute model) => await repo.AddAsync(model));
        app.MapPut($"{Route}/{{id:guid}}", async (IAttributeRepository repo,Guid id, Attribute model) => await repo.UpdateAsync(id,model));
        app.MapDelete($"{Route}/{{id:guid}}", async (IAttributeRepository repo, Guid id) => await repo.DeleteAsync(id));
    }
    public void DefineServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var environment = Environment.GetEnvironmentVariables();
        var connectionString = builder.Configuration.GetConnectionString("PlaysOfRpg");
        connectionString = string.Format(connectionString,
            environment["DATABASE_HOST"],
            environment["DATABASE_NAME"],
            environment["DATABASE_USER"],
            environment["DATABASE_PASSWORD"]);
        services.AddDbContext<CharacterDbContext>(o =>
        {
            o.UseNpgsql(connectionString);
        });
        services.TryAddSingleton<IAttributeRepository, InMemoryAttributeRepository>();
    }
}