using System.Text.Json;
using EmerchAPI.Models.Dtos;
using EmerchAPI.Services.Abstraction;
using EmerchAPI.Utils;

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
        var request = new HttpRequestMessage(HttpMethod.Post, "records");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(entity.Cost.ToString()), nameof(entity.Cost).ToLower());
        content.Add(new StringContent(entity.Description), nameof(entity.Description).ToLower());
        content.Add(new StringContent(entity.Title), nameof(entity.Title).ToLower());
        content.Add(new StringContent(entity.ImageUrl), nameof(entity.ImageUrl).ToCamelCase());
        content.Add(new StringContent(entity.AvailableAmount.ToString()), nameof(entity.AvailableAmount).ToCamelCase());
        content.Add(new StringContent(JsonSerializer.Serialize(entity.ProductContents)), nameof(entity.ProductContents).ToCamelCase());
        request.Content = content;
        
        var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadFromJsonAsync<Product>();

        return result ?? new Product();
    }

    public async Task<Product> Delete(string id)
    {
        var response = await _httpClient.DeleteAsync($"records/{id}");
        return new Product();
    }

    public async Task<Product> Update(Product entity)
    {
        var request = new HttpRequestMessage(HttpMethod.Patch, $"records/{entity.Id}");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(entity.Cost.ToString()), nameof(entity.Cost).ToLower());
        content.Add(new StringContent(entity.Description), nameof(entity.Description).ToLower());
        content.Add(new StringContent(entity.Title), nameof(entity.Title).ToLower());
        content.Add(new StringContent(entity.ImageUrl), nameof(entity.ImageUrl).ToCamelCase());
        content.Add(new StringContent(entity.AvailableAmount.ToString()), nameof(entity.AvailableAmount).ToCamelCase());
        request.Content = content;
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Product>();

        return result ?? new Product();
    }
}