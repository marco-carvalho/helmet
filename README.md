# Helmet

[![NuGet version](https://buildstats.info/nuget/Helmet)](https://www.nuget.org/packages/Helmet/) [![Build status](https://github.com/marco-carvalho/helmet/actions/workflows/build.yml/badge.svg)](https://github.com/marco-carvalho/helmet/actions/workflows/build.yml/badge.svg) [![Code coverage](https://codecov.io/gh/marco-carvalho/helmet/branch/main/graph/badge.svg)](https://codecov.io/gh/marco-carvalho/helmet)

Secures .NET apps by setting HTTP response headers. Exactly like [Helmet](https://github.com/helmetjs/helmet), but for C#.

## Get started

Install it via the .NET SDK:

```sh
dotnet add package Helmet
```

Use it in your project:

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
- `Referrer-Policy`: Controls the [`Referer`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referer) header
- `Strict-Transport-Security`: Tells browsers to prefer HTTPS
- `X-Content-Type-Options`: Avoids [MIME sniffing](https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types#mime_sniffing)
- `X-DNS-Prefetch-Control`: Controls DNS prefetching
- `X-Download-Options`: Forces downloads to be saved
- `X-Frame-Options`: Legacy header that mitigates [clickjacking](https://en.wikipedia.org/wiki/Clickjacking) attacks
- `X-Permitted-Cross-Domain-Policies`: Controls cross-domain behavior for Adobe products, like Acrobat
- `X-Powered-By`: Info about the web server. Removed because it could be used in simple attacks
- `X-XSS-Protection`: Legacy header that tries to mitigate [XSS attacks](https://developer.mozilla.org/en-US/docs/Glossary/Cross-site_scripting), but makes things worse, so Helmet disables it

Headers can also be disabled. For example, here's how you disable the `Cross-Origin-Opener-Policy` headers:

```cs
using Helmet;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHelmet(options =>
{
    // This only disables Cross-Origin-Opener-Policy
    options.UseCrossOriginOpenerPolicy = false;
});

app.MapGet("/", () => "Hello World!");

app.Run();
```
