using System.Text.Json;
using EmerchAPI.Models.Dtos;
using EmerchAPI.Services.Abstraction;
using EmerchAPI.Utils;

namespace EmerchAPI.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;
    
    public CustomerService(
        HttpClient httpClient, 
        IProductService productService)
    {
        _httpClient = httpClient;
    }
    
    public async Task<CustomerListResponse> GetItems()
    {
        var response = await _httpClient.GetAsync("records");
        var result = await response.Content.ReadFromJsonAsync<CustomerListResponse>();

        return result ?? new CustomerListResponse();
    }

    public async Task<Customer> GetItemById(string id)
    {
        var response = await _httpClient.GetAsync($"records/{id}");
        var result = await response.Content.ReadFromJsonAsync<Customer>();

        return result ?? new Customer();
    }
    
    public async Task<Customer?> GetItemByTelegramId(string telegramId)
    {
        var response = await _httpClient.GetAsync($"records?filter=(telegramId='{telegramId}')");
        var searchResult = await response.Content.ReadFromJsonAsync<CustomerListResponse>();
        var result = searchResult?.Items.FirstOrDefault();
        return result;
    }

    public async Task<Customer> Create(Customer entity)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "records");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(entity.TelegramId), nameof(entity.TelegramId).ToCamelCase());
        if (!string.IsNullOrEmpty(entity.Nickname))
            content.Add(new StringContent(entity.Nickname), nameof(entity.Nickname).ToLower());
        if (!string.IsNullOrEmpty(entity.FirstName))
            content.Add(new StringContent(entity.FirstName), nameof(entity.FirstName).ToLower());
        if (!string.IsNullOrEmpty(entity.LastName))
            content.Add(new StringContent(entity.LastName), nameof(entity.LastName).ToLower());
        content.Add(new StringContent(entity.ThumbnailUrl), nameof(entity.ThumbnailUrl).ToCamelCase());
        content.Add(new StringContent(entity.ECoins.ToString()), nameof(entity.ECoins).ToLower());
        request.Content = content;
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Customer>();
        return result ?? new Customer();
    }

    public async Task<Customer> Delete(string id)
    {
        var response = await _httpClient.DeleteAsync($"records/{id}");
        return new Customer();
    }

    public async Task<Customer> Update(Customer entity)
    {
        var request = new HttpRequestMessage(HttpMethod.Patch, $"records/{entity.Id}");
        var content = new MultipartFormDataContent();
        if (!string.IsNullOrEmpty(entity.Nickname))
            content.Add(new StringContent(entity.Nickname), nameof(entity.Nickname).ToLower());
        if (!string.IsNullOrEmpty(entity.FirstName))
            content.Add(new StringContent(entity.FirstName), nameof(entity.FirstName).ToLower());
        if (!string.IsNullOrEmpty(entity.LastName))
            content.Add(new StringContent(entity.LastName), nameof(entity.LastName).ToLower());
        content.Add(new StringContent(entity.ThumbnailUrl), nameof(entity.ThumbnailUrl).ToCamelCase());
        content.Add(new StringContent(entity.ECoins.ToString()), nameof(entity.ECoins).ToLower());
        request.Content = content;
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Customer>();

        return result ?? new Customer();
    }
}