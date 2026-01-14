namespace OrderService.Integration;

public interface ICatalogClient
{
    Task<CatalogProductDto?> GetProductByIdAsync(Guid productId);
}
