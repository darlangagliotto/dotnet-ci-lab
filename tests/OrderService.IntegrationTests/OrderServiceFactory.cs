using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Integration;
using OrderService.IntegrationTests.Fakes;

namespace OrderService.IntegrationTests;

public class OrderServiceFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services => 
        {
            var descriptor = services.Single(
                d => d.ServiceType == typeof(ICatalogClient)
            );

            services.Remove(descriptor);
            services.AddSingleTon<ICatalogClient, FakeCatalogClient>();
        });
    }
}