using Abstractions.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastructure.Endpoints;

public class SwaggerEndpoint : IEndpoint
{
    public void DefineEndpoints(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlaysOfRpg v1"));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "PlaysOfRpg", Version = "v1"});
        });
    }
}