using System.Text;
using System.Text.Json;
using EmerchAPI.Models;
using EmerchAPI.Services.Abstraction;

namespace EmerchAPI.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;
    
    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ListResponse<Customer>> GetItems()
    {
        var response = await _httpClient.GetAsync("records");
        var json = await response.Content.ReadAsStringAsync();
        var result = await response.Content.ReadFromJsonAsync<ListResponse<Customer>>();

        return result ?? new ListResponse<Customer>();
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