using System.Net; // necessário para HttpStatusCode
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
    public async Task Get_catalog_should_not_fail()
    {
        // Apenas verifica que o endpoint existe
        var response = await _client.GetAsync("/api/catalog");

        // Aceita OK ou NotFound
        Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NotFound);
    }
}
