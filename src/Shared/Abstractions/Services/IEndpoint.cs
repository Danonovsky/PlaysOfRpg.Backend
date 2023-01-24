using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Abstractions.Services;

public interface IEndpoint
{
    void DefineEndpoints(WebApplication app);
    void DefineServices(WebApplicationBuilder builder);
}

public static class EndpointExtensions
{
    public static void AddEndpoints(this WebApplicationBuilder builder, params Type[] scanMarkers)
    {
        var endpoints = new List<IEndpoint>();
        foreach (var marker in scanMarkers)
        {
            endpoints.AddRange(
                marker.Assembly.ExportedTypes
                    .Where(x => typeof(IEndpoint).IsAssignableFrom(x) && !x.IsInterface)
                    .Select(Activator.CreateInstance).Cast<IEndpoint>());
        }

        foreach (var endpoint in endpoints)
        {
            endpoint.DefineServices(builder);
        }

        builder.Services.AddSingleton(endpoints as IReadOnlyCollection<IEndpoint>);
    }

    public static void UseEndpoints(this WebApplication app)
    {
        var endpoints = app.Services.GetRequiredService<IReadOnlyCollection<IEndpoint>>();
        foreach (var definition in endpoints)
        {
            definition.DefineEndpoints(app);
        }
    }
}