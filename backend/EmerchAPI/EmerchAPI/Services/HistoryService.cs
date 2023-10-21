using EmerchAPI.Models.Dtos;
using EmerchAPI.Services.Abstraction;

namespace EmerchAPI.Services;

public class HistoryService : IHistoryService
{
    private readonly HttpClient _httpClient;
    private readonly IProductService _productService;
    
    public HistoryService(
        HttpClient httpClient, 
        IProductService productService)
    {
        _httpClient = httpClient;
        _productService = productService;
    }
    
    public async Task<PurchaseListDto> GetPurchaseHistory(string userId)
    {
        var productListResponse = await _productService.GetItems();
        var productsDict = productListResponse.Items.ToDictionary(x => x.Id, y => y.Title);
        
        var response = await _httpClient.GetAsync($"records?filter=(customerId='{userId}')");
        var purchasesResponse = await response.Content.ReadFromJsonAsync<PurchaseListResponse>();
        var productIds = purchasesResponse?.Items.Select(item => item.ProductId).Distinct().ToList() ?? new List<string>();

        var result = new PurchaseListDto()
        {
            CustomerId = userId,
            Purchases = new List<PurchaseDto>()
        };

        foreach (var productId in productIds)
        {
            result.Purchases.Add(new PurchaseDto
            {
                ProductId = productId,
                Title = productsDict.GetValueOrDefault(productId),
                Count = purchasesResponse.Items?.Where(item=> item.ProductId == productId).Count() ?? 0
            });
        }
        
        return result;
    }
}