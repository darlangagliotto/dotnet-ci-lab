using OrderService.Domain;

namespace OrderService.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Order? GetById(Guid id);
}
