namespace CatalogService.Domain;

public class Product
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public bool IsActive { get; }

    public Product(Guid id, string name, decimal price, bool isActive)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        Id = id;
        Name = name;
        Price = price;
        IsActive = isActive;
    }
}
