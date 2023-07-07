using System;
using Microsoft.AspNetCore.Builder;

namespace Helmet;

public static class HelmetMiddlewareExtensions
{
    public static IApplicationBuilder UseHelmet(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HelmetMiddleware>(new HelmetOptions());
    }

    public static IApplicationBuilder UseHelmet(this IApplicationBuilder builder, Action<HelmetOptions> configureOptions)
    {
        var options = new HelmetOptions();
        configureOptions(options);
        return builder.UseMiddleware<HelmetMiddleware>(options);
    }
}
