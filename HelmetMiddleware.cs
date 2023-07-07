using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Helmet;

public class HelmetMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HelmetOptions _options;

    public HelmetMiddleware(RequestDelegate next, HelmetOptions options)
    {
        _next = next;
        _options = options;
    }

    public async Task Invoke(HttpContext context)
    {
        if (_options.UseContentSecurityPolicy)
        {
            context.Response.Headers["Content-Security-Policy"] = "default-src 'self';base-uri 'self';font-src 'self' https: data:;form-action 'self';frame-ancestors 'self';img-src 'self' data:;object-src 'none';script-src 'self';script-src-attr 'none';style-src 'self' https: 'unsafe-inline';upgrade-insecure-requests";
        }

        if (_options.UseCrossOriginOpenerPolicy)
        {
            context.Response.Headers["Cross-Origin-Opener-Policy"] = "same-origin";
        }

        if (_options.UseCrossOriginResourcePolicy)
        {
            context.Response.Headers["Cross-Origin-Resource-Policy"] = "same-origin";
        }

        if (_options.UseOriginAgentCluster)
        {
            context.Response.Headers["Origin-Agent-Cluster"] = "?1";
        }

        if (_options.UseReferrerPolicy)
        {
            context.Response.Headers["Referrer-Policy"] = "no-referrer";
        }

        if (_options.UseStrictTransportSecurity)
        {
            context.Response.Headers["Strict-Transport-Security"] = "max-age=15552000; includeSubDomains";
        }

        if (_options.UseXContentTypeOptions)
        {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
        }

        if (_options.UseDnsPrefetchControl)
        {
            context.Response.Headers["X-DNS-Prefetch-Control"] = "off";
        }

        if (_options.UseDownloadOptions)
        {
            context.Response.Headers["X-Download-Options"] = "noopen";
        }

        if (_options.UseFrameOptions)
        {
            context.Response.Headers["X-Frame-Options"] = "SAMEORIGIN";
        }

        if (_options.UsePermittedCrossDomainPolicies)
        {
            context.Response.Headers["X-Permitted-Cross-Domain-Policies"] = "none";
        }

        if (_options.RemoveXPoweredBy)
        {
            context.Response.Headers.Remove("X-Powered-By");
        }

        if (_options.UseXXssProtection)
        {
            context.Response.Headers["X-XSS-Protection"] = "0";
        }

        await _next(context);
    }
}
