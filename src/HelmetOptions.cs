namespace Helmet;

public class HelmetOptions
{
    public bool UseContentSecurityPolicy { get; set; } = true;
    public bool UseCrossOriginOpenerPolicy { get; set; } = true;
    public bool UseCrossOriginResourcePolicy { get; set; } = true;
    public bool UseOriginAgentCluster { get; set; } = true;
    public bool UseReferrerPolicy { get; set; } = true;
    public bool UseServer { get; set; } = false;
    public bool UseStrictTransportSecurity { get; set; } = true;
    public bool UseXContentTypeOptions { get; set; } = true;
    public bool UseDnsPrefetchControl { get; set; } = true;
    public bool UseDownloadOptions { get; set; } = true;
    public bool UseFrameOptions { get; set; } = true;
    public bool UsePermittedCrossDomainPolicies { get; set; } = true;
    public bool UseXPoweredBy { get; set; } = false;
    public bool UseXXssProtection { get; set; } = true;
}
