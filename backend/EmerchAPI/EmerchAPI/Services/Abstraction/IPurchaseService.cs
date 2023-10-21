using EmerchAPI.Models.Dtos;

namespace EmerchAPI.Services.Abstraction;

public interface IPurchaseService
{ 
    Task<PurchaseListDto> GetPurchaseHistory(string userId);
    Task<Purchase> Purchase(string userId, string productId);
    Task<CustomerListResponse> Exchange(string dealerId, string receiverId, int amount = 100);
}