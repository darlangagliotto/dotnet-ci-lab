using CatalogService.Domain;

namespace CatalogService.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new()
    {
        new Product(
            Guid.Parse("11111111-1111-1111-1111-111111111111"),
            "Notebook",
            4500m,
            true
        ),
        new Product(
            Guid.Parse("22222222-2222-2222-2222-222222222222"),
            "Mouse",
            150m,
            true
        )
    };

    public IReadOnlyCollection<Product> GetAll() => _products;

    public Product? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);
}