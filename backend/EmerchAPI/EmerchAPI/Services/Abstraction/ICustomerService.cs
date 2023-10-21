using EmerchAPI.Models.Dtos;

namespace EmerchAPI.Services.Abstraction;

public interface ICustomerService : IDatabaseService<Customer>
{
    public Task<CustomerListResponse> GetItems();
    Task<PurchaseListResponse> GetPurchaseHistory(string userId);
}