using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using repom.application.AppService;
using repom.application.Interface;
using repom.bootstrapper.Configurations.Performance;
using repom.bootstrapper.Utils;
using repom.domain.core.Interface;
using repom.domain.core.Repositories;
using repom.domain.core.Service;
using repom.persistence.Context;
using repom.persistence.Repository;

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

        services.AddScoped<IPersonAppService, PersonAppService>();

        #endregion

        #region .::Services

        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IDepartmentService,DepartmentService>();
        services.AddScoped<IPhoneService,PhoneService>();
        services.AddScoped<IAddressService,AddressService>();
        services.AddScoped<IJobService,JobService>();
        #endregion

        #region .::Repositories

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IDepartmentRepository,DepartmentRepository>();
        services.AddScoped<IPhoneRepository,PhoneRepository>();
        services.AddScoped<IAddressRepository,AddressRepository>();
        services.AddScoped<IJobRepository,JobRepository>();
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