using CatalogService.Controllers;
using CatalogService.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Tests.Controllers;

public class CatalogControllerTests
{
    private readonly CatalogController _controller;

    public CatalogControllerTests()
    {
        IProductRepository repository = new InMemoryProductRepository();
        _controller = new CatalogController(repository);
    }

    [Fact]
    public void GetProducts_Should_Return_Ok_With_Products()
    {
        var result = _controller.GetProducts();

        var okResult = result as OkObjectResult;

        okResult.Should().NotBeNull();
        okResult!.Value.Should().NotBeNull();
    }

    [Fact]
    public void GetProductById_Should_Return_NotFound_When_Product_Does_Not_Exist()
    {
        var result = _controller.GetProductById(Guid.NewGuid());

        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public void GetProductById_Should_Return_Ok_When_Product_Exists()
    {
        var repository = new InMemoryProductRepository();
        var existingProduct = repository.GetAll().First();

        var controller = new CatalogController(repository);

        var result = controller.GetProductById(existingProduct.Id);

        result.Should().BeOfType<OkObjectResult>();
    }
}
