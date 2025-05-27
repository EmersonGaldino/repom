using repom.application.api.AutoMapper;
using repom.bootstrapper.Configurations.AutoMapper;
using repom.bootstrapper.Configurations.Cors;
using repom.bootstrapper.Configurations.Injections;
using repom.bootstrapper.Configurations.Logger;
using repom.bootstrapper.Configurations.swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var provider = services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
services.AddAutoMapperConfiguration();
services.AddAutoMapperModelViewConfiguration();

LoggerBuilder.ConfigureLogging();
services.AddProtectedControllers();
services.AddServices(configuration);
services.AddCors();
services.AddSwagger();
services.AddDatabaseConfiguration(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCorsConfig();
app.UseAuthorization();
app.UseRouting();
app.UseSwaggerConfig();
app.UseEndpointsConfig();
app.UseHttpsRedirection();


app.Run();