using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
namespace Soenneker.DigitalOcean.HttpClients.Abstract;
/// <summary>
/// Provides a cached, authenticated <see cref="HttpClient"/> for the DigitalOcean API.
/// </summary>
public interface IDigitalOceanOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured HTTP client used by the Digital Ocean OpenAPI HTTP Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
