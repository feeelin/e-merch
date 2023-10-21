using EmerchAPI.Models.Dtos;

namespace EmerchAPI.Services.Abstraction;

public interface IHistoryService
{ 
    Task<PurchaseListDto> GetPurchaseHistory(string userId);
}