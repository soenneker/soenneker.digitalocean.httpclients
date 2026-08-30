[![](https://img.shields.io/nuget/v/soenneker.digitalocean.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.digitalocean.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.digitalocean.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.digitalocean.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.digitalocean.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.digitalocean.httpclients/actions/workflows/codeql.yml)

# Soenneker.DigitalOcean.HttpClients

Provides a cached `HttpClient` configured for DigitalOcean’s API base address and bearer authentication.

## Installation

```bash
dotnet add package Soenneker.DigitalOcean.HttpClients
```

## Configuration

```json
{
  "DigitalOcean": {
    "AccessToken": "your-personal-access-token"
  }
}
```

Store the token in user secrets, environment-backed configuration, or a secret manager rather than source control.

Optional settings:

```json
{
  "DigitalOcean": {
    "ClientBaseUrl": "https://api.digitalocean.com",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

The template replaces every literal `{token}` with `AccessToken`. Treat `ClientBaseUrl`, the header name, and the template as trusted configuration: the resulting authentication header is sent to that base address.

## Registration and use

```csharp
using Soenneker.DigitalOcean.HttpClients.Abstract;
using Soenneker.DigitalOcean.HttpClients.Registrars;

services.AddDigitalOceanOpenApiHttpClientAsSingleton();

public sealed class DropletReader(IDigitalOceanOpenApiHttpClient clientProvider)
{
    public async Task<string> GetDroplets(CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);
        return await client.GetStringAsync("/v2/droplets", cancellationToken);
    }
}
```

`Get` returns the cached client; do not dispose that `HttpClient` yourself. The provider owns it and removes it from the cache when the provider is disposed.

`AddDigitalOceanOpenApiHttpClientAsScoped()` scopes the provider while retaining the singleton client cache. Disposing a scope releases the provider without destroying the shared `HttpClient`. Use singleton registration when the provider itself should also live for the application lifetime.

This package configures transport only. It does not deserialize DigitalOcean responses, follow pagination links, or translate non-success status codes. Use the companion OpenAPI client/util packages or handle those concerns in the caller.
