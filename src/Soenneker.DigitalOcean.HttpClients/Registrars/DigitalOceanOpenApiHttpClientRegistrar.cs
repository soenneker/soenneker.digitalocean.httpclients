using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DigitalOcean.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.DigitalOcean.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class DigitalOceanOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="DigitalOceanOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddDigitalOceanOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IDigitalOceanOpenApiHttpClient, DigitalOceanOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DigitalOceanOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddDigitalOceanOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsScoped()
                .TryAddScoped<IDigitalOceanOpenApiHttpClient, DigitalOceanOpenApiHttpClient>();

        return services;
    }
}
