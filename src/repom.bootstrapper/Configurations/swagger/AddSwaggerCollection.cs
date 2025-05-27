using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using repom.bootstrapper.Configurations.Cors;

namespace repom.bootstrapper.Configurations.swagger;

public static partial class AddSwaggerCollection
{
    public static IServiceCollection AddProtectedControllers(this IServiceCollection services)
    {
        services.AddControllers(config =>
        {
          
            config.Filters.Add(typeof(ValidateModelStateAttribute));
        });

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddMvc()
            .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Repom Teste",
                Description = " Galdino"
            });
        });
        return services;
    }
}