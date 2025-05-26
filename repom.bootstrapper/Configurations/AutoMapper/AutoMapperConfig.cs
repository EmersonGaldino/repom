using Microsoft.Extensions.DependencyInjection;

namespace repom.bootstrapper.Configurations.AutoMapper;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfile));
    }
}