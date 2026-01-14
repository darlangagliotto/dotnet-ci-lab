namespace CatalogService.Controllers;

public record ProductResponse(
    Guid Id,
    string Name,
    decimal Price
);
