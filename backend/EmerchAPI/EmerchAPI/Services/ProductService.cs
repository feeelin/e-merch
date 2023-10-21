using System.Text;
using System.Text.Json;
using EmerchAPI.Models.Dtos;
using EmerchAPI.Services.Abstraction;

namespace EmerchAPI.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductListResponse> GetItems()
    {
        var response = await _httpClient.GetAsync("records");
        var result = await response.Content.ReadFromJsonAsync<ProductListResponse>();

        return result ?? new ProductListResponse();
    }

    public async Task<Product> GetItemById(string id)
    {
        var response = await _httpClient.GetAsync($"records/{id}");
        var result = await response.Content.ReadFromJsonAsync<Product>();

        return result ?? new Product();
    }

    public async Task<Product> Create(Product entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync($"records", content);
        var result = await response.Content.ReadFromJsonAsync<Product>();

        return result ?? new Product();
    }

    public async Task<Product> Delete(string id)
    {
        var response = await _httpClient.DeleteAsync($"records/{id}");
        var result = await response.Content.ReadFromJsonAsync<Product>();

        return result ?? new Product();
    }

    public async Task<Product> Update(Product entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PutAsync($"records", content);
        var result = await response.Content.ReadFromJsonAsync<Product>();

        return result ?? new Product();
    }
}