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
        if (!_options.UseContentSecurityPolicy)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.ContentSecurityPolicy);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.ContentSecurityPolicy] = HttpHeaderValueConstants.ContentSecurityPolicy;
        }

        if (!_options.UseCrossOriginOpenerPolicy)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.CrossOriginOpenerPolicy);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.CrossOriginOpenerPolicy] = HttpHeaderValueConstants.CrossOriginOpenerPolicy;
        }

        if (!_options.UseCrossOriginResourcePolicy)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.CrossOriginResourcePolicy);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.CrossOriginResourcePolicy] = HttpHeaderValueConstants.CrossOriginResourcePolicy;
        }

        if (!_options.UseOriginAgentCluster)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.OriginAgentCluster);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.OriginAgentCluster] = HttpHeaderValueConstants.OriginAgentCluster;
        }

        if (!_options.UseReferrerPolicy)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.ReferrerPolicy);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.ReferrerPolicy] = HttpHeaderValueConstants.ReferrerPolicy;
        }

        if (!_options.UseStrictTransportSecurity)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.StrictTransportSecurity);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.StrictTransportSecurity] = HttpHeaderValueConstants.StrictTransportSecurity;
        }

        if (!_options.UseXContentTypeOptions)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.XContentTypeOptions);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.XContentTypeOptions] = HttpHeaderValueConstants.XContentTypeOptions;
        }

        if (!_options.UseDnsPrefetchControl)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.DnsPrefetchControl);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.DnsPrefetchControl] = HttpHeaderValueConstants.DnsPrefetchControl;
        }

        if (!_options.UseDownloadOptions)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.DownloadOptions);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.DownloadOptions] = HttpHeaderValueConstants.DownloadOptions;
        }

        if (!_options.UseFrameOptions)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.FrameOptions);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.FrameOptions] = HttpHeaderValueConstants.FrameOptions;
        }

        if (!_options.UsePermittedCrossDomainPolicies)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.PermittedCrossDomainPolicies);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.PermittedCrossDomainPolicies] = HttpHeaderValueConstants.PermittedCrossDomainPolicies;
        }

        if (!_options.UseXPoweredBy)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.XPoweredBy);
        }

        if (!_options.UseXXssProtection)
        {
            context.Response.Headers.Remove(HttpHeaderKeyConstants.XXssProtection);
        }
        else
        {
            context.Response.Headers[HttpHeaderKeyConstants.XXssProtection] = HttpHeaderValueConstants.XXssProtection;
        }

        await _next(context);
    }
}
