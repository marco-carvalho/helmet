using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using Helmet;

namespace HelmetTest;

public class HelmetMiddlewareTests
{
    private readonly Mock<HttpResponse> _responseMock;
    private readonly Mock<HttpContext> _contextMock;
    private readonly Mock<RequestDelegate> _nextMock;

    public HelmetMiddlewareTests()
    {
        _responseMock = new Mock<HttpResponse>();
        _contextMock = new Mock<HttpContext>();
        _nextMock = new Mock<RequestDelegate>();

        _responseMock.SetupGet(r => r.Headers).Returns(new HeaderDictionary());
        _contextMock.Setup(c => c.Response).Returns(_responseMock.Object);
    }

    private async Task InvokeMiddlewareWithOptions(HelmetOptions options)
    {
        var middleware = new HelmetMiddleware(_nextMock.Object, options);
        await middleware.Invoke(_contextMock.Object);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.ContentSecurityPolicy)]
    [InlineData(false, null)]
    public async Task Invoke_SetsContentSecurityPolicyHeader_GivenUseContentSecurityPolicyOption(bool useContentSecurityPolicy, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseContentSecurityPolicy = useContentSecurityPolicy
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.ContentSecurityPolicy]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.CrossOriginOpenerPolicy)]
    [InlineData(false, null)]
    public async Task Invoke_SetsCrossOriginOpenerPolicyHeader_GivenUseCrossOriginOpenerPolicyOption(bool useCrossOriginOpenerPolicy, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseCrossOriginOpenerPolicy = useCrossOriginOpenerPolicy
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.CrossOriginOpenerPolicy]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.CrossOriginResourcePolicy)]
    [InlineData(false, null)]
    public async Task Invoke_SetsCrossOriginResourcePolicyHeader_GivenUseCrossOriginResourcePolicyOption(bool useCrossOriginResourcePolicy, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseCrossOriginResourcePolicy = useCrossOriginResourcePolicy
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.CrossOriginResourcePolicy]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.OriginAgentCluster)]
    [InlineData(false, null)]
    public async Task Invoke_SetsOriginAgentClusterHeader_GivenUseOriginAgentClusterOption(bool useOriginAgentCluster, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseOriginAgentCluster = useOriginAgentCluster
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.OriginAgentCluster]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.ReferrerPolicy)]
    [InlineData(false, null)]
    public async Task Invoke_SetsReferrerPolicyHeader_GivenUseReferrerPolicyOption(bool useReferrerPolicy, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseReferrerPolicy = useReferrerPolicy
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.ReferrerPolicy]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.StrictTransportSecurity)]
    [InlineData(false, null)]
    public async Task Invoke_SetsStrictTransportSecurityHeader_GivenUseStrictTransportSecurityOption(bool useStrictTransportSecurity, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseStrictTransportSecurity = useStrictTransportSecurity
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.StrictTransportSecurity]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.XContentTypeOptions)]
    [InlineData(false, null)]
    public async Task Invoke_SetsXContentTypeOptionsHeader_GivenUseXContentTypeOptionsOption(bool useXContentTypeOptions, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseXContentTypeOptions = useXContentTypeOptions
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.XContentTypeOptions]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.DnsPrefetchControl)]
    [InlineData(false, null)]
    public async Task Invoke_SetsDnsPrefetchControlHeader_GivenUseDnsPrefetchControlOption(bool useDnsPrefetchControl, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseDnsPrefetchControl = useDnsPrefetchControl
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.DnsPrefetchControl]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.DownloadOptions)]
    [InlineData(false, null)]
    public async Task Invoke_SetsDownloadOptionsHeader_GivenUseDownloadOptionsOption(bool useDownloadOptions, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseDownloadOptions = useDownloadOptions
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.DownloadOptions]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.FrameOptions)]
    [InlineData(false, null)]
    public async Task Invoke_SetsFrameOptionsHeader_GivenUseFrameOptionsOption(bool useFrameOptions, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseFrameOptions = useFrameOptions
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.FrameOptions]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.PermittedCrossDomainPolicies)]
    [InlineData(false, null)]
    public async Task Invoke_SetsPermittedCrossDomainPoliciesHeader_GivenUsePermittedCrossDomainPoliciesOption(bool usePermittedCrossDomainPolicies, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UsePermittedCrossDomainPolicies = usePermittedCrossDomainPolicies
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.PermittedCrossDomainPolicies]);
    }

    [Theory]
    [InlineData(false, null)]
    public async Task Invoke_SetsXPoweredByHeader_GivenUseXPoweredByOption(bool useXPoweredBy, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseXPoweredBy = useXPoweredBy
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.XPoweredBy]);
    }

    [Theory]
    [InlineData(true, HttpHeaderValueConstants.XXssProtection)]
    [InlineData(false, null)]
    public async Task Invoke_SetsXXssProtectionHeader_GivenUseXXssProtectionOption(bool useXXssProtection, string expectedHeaderValue)
    {
        var options = new HelmetOptions
        {
            UseXXssProtection = useXXssProtection
        };

        await InvokeMiddlewareWithOptions(options);

        var headers = _responseMock.Object.Headers;
        Assert.Equal(expectedHeaderValue, headers[HttpHeaderKeyConstants.XXssProtection]);
    }
}