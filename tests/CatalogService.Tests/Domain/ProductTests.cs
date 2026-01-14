using CatalogService.Domain;
using FluentAssertions;

namespace CatalogService.Tests.Domain;

public class ProductTests
{
    [Fact]
    public void Constructor_Should_Create_Product_When_Data_Is_Valid()
    {
        var id = Guid.NewGuid();

        var product = new Product(id, "Keyboard", 200m, true);

        product.Id.Should().Be(id);
        product.Name.Should().Be("Keyboard");
        product.Price.Should().Be(200m);
        product.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Constructor_Should_Throw_When_Name_Is_Invalid()
    {
        var act = () => new Product(Guid.NewGuid(), "", 10m, true);

        act.Should().Throw<ArgumentException>().WithMessage("*name*");
    }

    [Fact]
    public void Constructor_Should_Throw_When_Price_Is_Invalid()
    {
        var act = () => new Product(Guid.NewGuid(), "Keyboard", 0m, true);

        act.Should().Throw<ArgumentException>().WithMessage("*price*");
    }
}