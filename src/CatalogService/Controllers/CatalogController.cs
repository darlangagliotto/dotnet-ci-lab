using CatalogService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers;

[ApiController]
[Route("api/catalog")]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _repository;

    public CatalogController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("products")]
    public IActionResult GetProducts()
    {
        var products = _repository.GetAll();
        return Ok(products);
    }

    [HttpGet("products/{id:guid}")]
    public IActionResult GetProductById(Guid id)
    {
        var product = _repository.GetById(id);

        if (product is null)
            return NotFound();

        return Ok(product);
    }
}