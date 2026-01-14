using System.Net;
using System.Net.Http.Json;
using FluentAssertions;

namespace OrderService.IntegrationTests;

public class CreateOrderTests : IClassFixture<OrderServiceFactory>
{
    private readonly HttpClient _client;

    public CreateOrderTests(OrderServiceFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Create_order_with_valid_product_returns_created_order()
    {
        var request = new
        {
            productId = Guid.NewGuid();
            quantity = 2
        };

        var responsse = await _client.PostAsJsonAsync("/api/orders", request);
        responsse.StatusCode.Should().Be(HttpStatusCode.Created);
        var order = await response.Content.ReadFromJsonAsync<OrderResponse>();

        order.Should().NotBeNull();
        order!.Items.Should().HaveCount(1);
        order.Total.Should().Be(20m);
    }
}