namespace OrderService.Domain;

public class OrderItem
{
    public Guid ProductId { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }

    public decimal Total => Quantity * UnitPrice;

    public OrderItem(Guid productId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be greater than zero");

        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
