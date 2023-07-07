namespace Helmet;

public static class HttpHeaderValueConstants
{
    public const string ContentSecurityPolicy = "default-src 'self';base-uri 'self';font-src 'self' https: data:;form-action 'self';frame-ancestors 'self';img-src 'self' data:;object-src 'none';script-src 'self';script-src-attr 'none';style-src 'self' https: 'unsafe-inline';upgrade-insecure-requests";
    public const string CrossOriginOpenerPolicy = "same-origin";
    public const string CrossOriginResourcePolicy = "same-origin";
    public const string OriginAgentCluster = "?1";
    public const string ReferrerPolicy = "no-referrer";
    public const string StrictTransportSecurity = "max-age=15552000; includeSubDomains";
    public const string XContentTypeOptions = "nosniff";
    public const string DnsPrefetchControl = "off";
    public const string DownloadOptions = "noopen";
    public const string FrameOptions = "SAMEORIGIN";
    public const string PermittedCrossDomainPolicies = "none";
    public const string XXssProtection = "0";
}