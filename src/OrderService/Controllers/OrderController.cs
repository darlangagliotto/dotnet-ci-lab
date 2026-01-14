using Microsoft.AspNetCore.Mvc;
using OrderService.Domain;
using OrderService.Repositories;
using OrderService.Integration;

namespace OrderService.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repository;
    private readonly ICatalogClient _catalogClient;

    public OrderController(
        IOrderRepository repository,
        ICatalogClient catalogClient)
    {
        _repository = repository;
        _catalogClient = catalogClient;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderItemRequest request)
    {
        var product = await _catalogClient.GetProductByIdAsync(request.ProductId);

        if (product is null)
            return BadRequest("Product not found");

        var order = new Order(Guid.NewGuid());

        order.AddItem(new OrderItem(
            product.Id,
            request.Quantity,
            product.Price
        ));

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
