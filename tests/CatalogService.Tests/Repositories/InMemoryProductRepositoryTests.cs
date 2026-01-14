using CatalogService.Repositories;
using FluentAssertions;

namespace CatalogService.Tests.Repositories;

public class InMemoryProductRepositoryTests
{
    private readonly InMemoryProductRepository _repository;

    public InMemoryProductRepositoryTests()
    {
        _repository = new InMemoryProductRepository();
    }

    [Fact]
    public void GetById_Should_Return_Product_When_Id_Exists()
    {
        var existingProduct = _repository.GetAll().First();
        var product = _repository.GetById(existingProduct.Id);

        product.Should().NotBeNull();
        product!.Id.Should().Be(existingProduct.Id);
    }

    [Fact]
    public void GetById_Should_Return_Null_When_Id_Does_Not_Exists()
    {
        var product = _repository.GetById(Guid.NewGuid());
        product.Should().BeNull();
    }
}