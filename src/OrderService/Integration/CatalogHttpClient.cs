using System.Net.Http.Json;

namespace OrderService.Integration;

public class CatalogHttpClient : ICatalogClient
{
    private readonly HttpClient _httpClient;

    public CatalogHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatalogProductDto?> GetProductByIdAsync(Guid productId)
    {
        var response = await _httpClient.GetAsync($"/api/catalog/{productId}");

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<CatalogProductDto>();
    }
}
