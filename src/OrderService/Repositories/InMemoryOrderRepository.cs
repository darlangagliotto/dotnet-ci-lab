using OrderService.Domain;

namespace OrderService.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _orders = new();

    public void Add(Order order)
    {
        _orders[order.Id] = order;
    }

    public Order? GetById(Guid id)
    {
        _orders.TryGetValue(id, out var order);
        return order;
    }
}
