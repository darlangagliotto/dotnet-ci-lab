namespace OrderService.IntegrationTests;

public class OrderResponse
{
    public Guid Id { get; set; }
    public decimal Total { get; set; }
    public List<OrderItemResponse> Items { get; set; } = [];
}

public class OrderItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
