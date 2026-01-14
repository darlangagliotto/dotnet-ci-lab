namespace OrderService.Controllers;

public record CreateOrderItemRequest(
    Guid ProductId,
    int Quantity
);
