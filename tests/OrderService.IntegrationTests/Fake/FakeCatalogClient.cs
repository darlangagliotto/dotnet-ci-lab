using OrderService.Integrations;

namespace OrderService.IntegrationTests.Fakes;

public class FakeCatalogClient : ICatalogClient
{
    public Task<CatalogProductDto?> GetProductByIdAsync(Guid productId)
    {
        return Task.FromResult<CatalogProductDto?>(
            new CatalogProductDto(
                productId,
                "Fake product",
                10m
            )
        );
    }
}