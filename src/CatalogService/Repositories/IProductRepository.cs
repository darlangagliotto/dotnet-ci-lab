using CatalogService.Domain;

namespace CatalogService.Repositories;

public interface IProductRepository
{
    IReadOnlyCollection<Product> GetAll();
    Product? GetById(Guid id);
}
