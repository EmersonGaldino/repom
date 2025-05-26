using Microsoft.AspNetCore.Builder;

namespace repom.bootstrapper.Configurations.Cors;

public static class ApplicationBuilderExtensionsCors
{
    public static void UseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors(x =>
        {
            x.AllowAnyHeader();
            x.AllowAnyMethod();
            x.AllowAnyOrigin();
        });
    }
    public static void UseEndpointsConfig(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}