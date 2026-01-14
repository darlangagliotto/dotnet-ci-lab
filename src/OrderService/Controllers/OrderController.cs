using Microsoft.AspNetCore.Mvc;
using OrderService.Domain;
using OrderService.Repositories;

namespace OrderService.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repository;

    public OrderController(IOrderRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult CreateOrder()
    {
        var order = new Order(Guid.NewGuid());
        _repository.Add(order);

        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = _repository.GetById(id);

        if (order is null)
            return NotFound();

        return Ok(order);
    }
}
