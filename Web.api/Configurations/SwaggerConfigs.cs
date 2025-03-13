using Microsoft.OpenApi.Models;

namespace Web.api.Configurations;

public static class SwaggerConfigs
{
    public static IServiceCollection AddSwaggerConfigs(this IServiceCollection services)
    {
        services.AddSwaggerGen(c => { c.EnableAnnotations(); });

        return services;
    }
}