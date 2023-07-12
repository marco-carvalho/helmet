using System.Collections.Generic;
using System;
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
        var optionsMapping = new Dictionary<Func<bool>, (string HeaderKey, string HeaderValue)>
        {
            { () => _options.UseContentSecurityPolicy, (HttpHeaderKeyConstants.ContentSecurityPolicy, HttpHeaderValueConstants.ContentSecurityPolicy) },
            { () => _options.UseCrossOriginOpenerPolicy, (HttpHeaderKeyConstants.CrossOriginOpenerPolicy, HttpHeaderValueConstants.CrossOriginOpenerPolicy) },
            { () => _options.UseCrossOriginResourcePolicy, (HttpHeaderKeyConstants.CrossOriginResourcePolicy, HttpHeaderValueConstants.CrossOriginResourcePolicy) },
            { () => _options.UseOriginAgentCluster, (HttpHeaderKeyConstants.OriginAgentCluster, HttpHeaderValueConstants.OriginAgentCluster) },
            { () => _options.UseReferrerPolicy, (HttpHeaderKeyConstants.ReferrerPolicy, HttpHeaderValueConstants.ReferrerPolicy) },
            { () => _options.UseStrictTransportSecurity, (HttpHeaderKeyConstants.StrictTransportSecurity, HttpHeaderValueConstants.StrictTransportSecurity) },
            { () => _options.UseXContentTypeOptions, (HttpHeaderKeyConstants.XContentTypeOptions, HttpHeaderValueConstants.XContentTypeOptions) },
            { () => _options.UseDnsPrefetchControl, (HttpHeaderKeyConstants.DnsPrefetchControl, HttpHeaderValueConstants.DnsPrefetchControl) },
            { () => _options.UseDownloadOptions, (HttpHeaderKeyConstants.DownloadOptions, HttpHeaderValueConstants.DownloadOptions) },
            { () => _options.UseFrameOptions, (HttpHeaderKeyConstants.FrameOptions, HttpHeaderValueConstants.FrameOptions) },
            { () => _options.UsePermittedCrossDomainPolicies, (HttpHeaderKeyConstants.PermittedCrossDomainPolicies, HttpHeaderValueConstants.PermittedCrossDomainPolicies) },
            { () => _options.UseXPoweredBy, (HttpHeaderKeyConstants.XPoweredBy, null) },
            { () => _options.UseXXssProtection, (HttpHeaderKeyConstants.XXssProtection, HttpHeaderValueConstants.XXssProtection) },
        };

        foreach (var option in optionsMapping)
        {
            if (!option.Key())
            {
                context.Response.Headers.Remove(option.Value.HeaderKey);
            }
            else if (option.Value.HeaderValue != null)
            {
                context.Response.Headers[option.Value.HeaderKey] = option.Value.HeaderValue;
            }
        }

        await _next(context);
    }
}
