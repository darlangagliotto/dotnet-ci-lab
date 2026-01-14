namespace OrderService.Domain;

public class Order
{
    public Guid Id { get; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public decimal Total => _items.Sum(i => i.Total);

    private readonly List<OrderItem> _items = new();

    public Order(Guid id)
    {
        Id = id;
    }

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }
}
