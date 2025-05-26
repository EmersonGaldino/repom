using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using repom.bootstrapper.Configurations.Performance;
using repom.bootstrapper.Utils;
using repom.persistence.Context;

namespace repom.bootstrapper.Configurations.Injections;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile(EnvironmentsHelper.Development
                ? "appsettings.Development.json"
                : EnvironmentsHelper.Docker
                    ? "appsettings.Docker.json"
                    : "appsettings.Production.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        #region .:: Configuration filter performace

        services.AddTransient<PerformaceFilters>();
        services.AddMvc(options => options.Filters.AddService<PerformaceFilters>())
            .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
            .SetCompatibilityVersion(CompatibilityVersion.Latest);

        #endregion

        #region .::AppServices

        // services.AddScoped<IUserAppService, UserAppService>();

        #endregion

        #region .::Services

        // services.AddScoped<IUserService, UserService>();

        #endregion

        #region .::Repositories

        // services.AddScoped<IUserRepository, UserRepository>();

        #endregion

        #region .::UnitOfWork

        services.AddScoped<ContextDb>();

        #endregion

        return services;
    }

    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ContextDb>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}