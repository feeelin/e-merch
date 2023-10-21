using EmerchAPI.Models.Dtos;

namespace EmerchAPI.Services.Abstraction;

public interface ICustomerService : IDatabaseService<Customer>
{
    public Task<CustomerListResponse> GetItems();
    public Task<Customer?> GetItemByTelegramId(string telegramId);
    public Task<CustomerListResponse> GetExchangePair(string dealerId, string receiverId);
    public Task<Customer> UpdateTokenAmount(string userId, int amount);
}