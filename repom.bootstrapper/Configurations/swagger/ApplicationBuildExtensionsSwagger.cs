using Microsoft.AspNetCore.Builder;

namespace repom.bootstrapper.Configurations.swagger;

public static class ApplicationBuildExtensionsSwagger
{
    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwaggerUI(swagger =>
        {
            swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Repom Galdino Teste");
            swagger.RoutePrefix = string.Empty;
        });
    }
}