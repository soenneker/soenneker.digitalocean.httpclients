using Soenneker.DigitalOcean.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.DigitalOcean.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DigitalOceanOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IDigitalOceanOpenApiHttpClient _httpclient;

    public DigitalOceanOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IDigitalOceanOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
