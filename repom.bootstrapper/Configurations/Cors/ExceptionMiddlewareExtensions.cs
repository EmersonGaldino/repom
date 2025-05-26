using Microsoft.AspNetCore.Builder;
using repom.bootstrapper.Configurations.Exceptions;

namespace repom.bootstrapper.Configurations.Cors;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionMiddleware>();
}