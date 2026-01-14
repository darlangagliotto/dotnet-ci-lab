using Microsoft.AspNetCore.Mvc;
using CatalogService.Repositories;

namespace CatalogService.Controllers;

[ApiController]
[Route("api/catalog")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var product = _repository.GetById(id);

        if (product is null)
            return NotFound();

        return Ok(new ProductResponse(
            product.Id,
            product.Name,
            product.Price
        ));
    }
}
