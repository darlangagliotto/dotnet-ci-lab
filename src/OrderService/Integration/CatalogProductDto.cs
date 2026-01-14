namespace OrderService.Integration;

public record CatalogProductDto(
    Guid Id,
    string Name,
    decimal Price
);
