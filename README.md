# Helmet

Helmet helps secure .NET apps by setting HTTP response headers.

## Get started

Here's a sample .NET app that uses `Helmet`:

```cs
using Helmet;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHelmet();

app.MapGet("/", () => "Hello World!");

app.Run();
```

By default, `Helmet` sets the following headers:

- `Content-Security-Policy`: A powerful allow-list of what can happen on your page which mitigates many attacks
- `Cross-Origin-Opener-Policy`: Helps process-isolate your page
- `Cross-Origin-Resource-Policy`: Blocks others from loading your resources cross-origin
- `Origin-Agent-Cluster`: Changes process isolation to be origin-based
- `Referrer-Policy`: Controls the [`Referer`][Referer] header
- `Strict-Transport-Security`: Tells browsers to prefer HTTPS
- `X-Content-Type-Options`: Avoids [MIME sniffing]
- `X-DNS-Prefetch-Control`: Controls DNS prefetching
- `X-Download-Options`: Forces downloads to be saved
- `X-Frame-Options`: Legacy header that mitigates [clickjacking] attacks
- `X-Permitted-Cross-Domain-Policies`: Controls cross-domain behavior for Adobe products, like Acrobat
- `X-Powered-By`: Info about the web server. Removed because it could be used in simple attacks
- `X-XSS-Protection`: Legacy header that tries to mitigate [XSS attacks][XSS], but makes things worse, so Helmet disables it

Headers can also be disabled. For example, here's how you disable the `Content-Security-Policy` and `X-Download-Options` headers:

```cs
using Helmet;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHelmet(options =>
{
    // This disables Cross-Origin-Opener-Policy
    options.UseCrossOriginOpenerPolicy = false;
});

app.MapGet("/", () => "Hello World!");

app.Run();
```