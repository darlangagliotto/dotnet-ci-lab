using System.Net;
using Xunit;

[Trait("Category", "Integration")]
public class CatalogApiTests : IClassFixture<PostgresFixture>
{
    private readonly HttpClient _client;

    public CatalogApiTests(PostgresFixture fixture)
    {
        var factory = new CustomWebApplicationFactory(fixture.ConnectionString);
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_catalog_should_return_ok()
    {
        var response = await _client.GetAsync("/api/catalog");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
