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
    public static IServiceCollection AddDigitalOceanOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IDigitalOceanOpenApiHttpClient, DigitalOceanOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DigitalOceanOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDigitalOceanOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IDigitalOceanOpenApiHttpClient, DigitalOceanOpenApiHttpClient>();

        return services;
    }
}
