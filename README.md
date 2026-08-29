[![](https://img.shields.io/nuget/v/soenneker.digitalocean.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.digitalocean.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.digitalocean.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.digitalocean.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.httpclients/)

# Soenneker.DigitalOcean.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.DigitalOcean.HttpClients
```

## Quick start

```csharp
using Soenneker.DigitalOcean.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddDigitalOceanOpenApiHttpClientAsSingleton();
```

Adds `DigitalOceanOpenApiHttpClient` as a singleton service.

## What you get

- `IDigitalOceanOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `DigitalOceanOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `DigitalOceanOpenApiHttpClientRegistrar.AddDigitalOceanOpenApiHttpClientAsSingleton(services)` | Adds `DigitalOceanOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `DigitalOceanOpenApiHttpClientRegistrar.AddDigitalOceanOpenApiHttpClientAsScoped(services)` | Adds `DigitalOceanOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
