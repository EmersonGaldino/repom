using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace repom.bootstrapper.Configurations.Logger;

public class LoggerBuilder
{
    public static void ConfigureLogging()
    {
        var env = "appsettings.json";

        var config = new ConfigurationBuilder()
            .AddJsonFile(env, optional: false, reloadOnChange: true)
            .AddJsonFile(env, optional: true).Build();
        
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithMachineName()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(ConfigureElasticSink(config))
            .Enrich.WithProperty("Environment", env)
            .ReadFrom.Configuration(config)
            .CreateLogger();
    }
    private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration) =>
        new(new Uri(configuration["KibanaConfiguration:Uri"]))
        {
            AutoRegisterTemplate = true,
            IndexFormat = configuration["KibanaConfiguration:ApplicationName"]
        };
}