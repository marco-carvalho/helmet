using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using Helmet;

namespace HelmetTest;

public class HelmetMiddlewareTests
{
    [Fact]
    public async Task Invoke_SetsCorrectHeaders_GivenCertainHelmetOptions()
    {
        // Arrange
        var headerDictionary = new HeaderDictionary();
        var responseMock = new Mock<HttpResponse>();
        responseMock.SetupGet(r => r.Headers).Returns(headerDictionary);

        var contextMock = new Mock<HttpContext>();
        contextMock.Setup(c => c.Response).Returns(responseMock.Object);

        var nextMock = new Mock<RequestDelegate>();

        var options = new HelmetOptions
        {
            UseContentSecurityPolicy = true,
            UseCrossOriginOpenerPolicy = false,
            UseCrossOriginResourcePolicy = true,
        };

        var middleware = new HelmetMiddleware(nextMock.Object, options);

        // Act
        await middleware.Invoke(contextMock.Object);

        // Assert
        var headers = contextMock.Object.Response.Headers;

        Assert.Equal("default-src 'self';base-uri 'self';font-src 'self' https: data:;form-action 'self';frame-ancestors 'self';img-src 'self' data:;object-src 'none';script-src 'self';script-src-attr 'none';style-src 'self' https: 'unsafe-inline';upgrade-insecure-requests", headers["Content-Security-Policy"]);
        Assert.False(headers.ContainsKey("Cross-Origin-Opener-Policy"));
        Assert.Equal("same-origin", headers["Cross-Origin-Resource-Policy"]);
    }
}