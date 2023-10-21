using System.Text;
using System.Text.Json;
using EmerchAPI.Models.Dtos;
using EmerchAPI.Services.Abstraction;

namespace EmerchAPI.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;
    private readonly IProductService _productService;
    
    public CustomerService(
        HttpClient httpClient, 
        IProductService productService)
    {
        _httpClient = httpClient;
        _productService = productService;
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

    public async Task<Customer> Create(Customer entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync($"records", content);
        var result = await response.Content.ReadFromJsonAsync<Customer>();

        return result ?? new Customer();
    }

    public async Task<Customer> Delete(string id)
    {
        var response = await _httpClient.DeleteAsync($"records/{id}");
        var result = await response.Content.ReadFromJsonAsync<Customer>();

        return result ?? new Customer();
    }

    public async Task<Customer> Update(Customer entity)
    {
        var json = JsonSerializer.Serialize(entity);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PutAsync($"records", content);
        var result = await response.Content.ReadFromJsonAsync<Customer>();

        return result ?? new Customer();
    }
}