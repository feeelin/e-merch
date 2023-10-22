using EmerchAPI.Models.Dtos;
using EmerchAPI.Services.Abstraction;

namespace EmerchAPI.Services;

public class PurchaseService : IPurchaseService
{
    private readonly HttpClient _httpClient;
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;
    
    public PurchaseService(
        HttpClient httpClient, 
        IProductService productService,
        ICustomerService customerService)
    {
        _httpClient = httpClient;
        _productService = productService;
        _customerService = customerService;
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
                Count = purchasesResponse?.Items?.Where(item=> item.ProductId == productId).Count() ?? 0
            });
        }
        
        return result;
    }

    public async Task<Purchase> Purchase(string userId, string productId)
    {
        var product = await _productService.GetItemById(productId);
        var customer = await _customerService.GetItemById(userId);

        if (customer.ECoins < product.Cost)
            throw new Exception($"Insufficient ECoins amount! Cannot purchase {product.Title}");
        
        var purchaseRequest = new HttpRequestMessage(HttpMethod.Post, $"records");
        var purchaseContent = new MultipartFormDataContent();
        purchaseContent.Add(new StringContent(userId), "customerId");
        purchaseContent.Add(new StringContent(productId), "productId");
        purchaseRequest.Content = purchaseContent;

        customer.ECoins -= product.Cost;
        
        var customerUpdate = _customerService.Update(customer);
        var purchaseResponse = _httpClient.SendAsync(purchaseRequest);
        await Task.WhenAll(customerUpdate, purchaseResponse);
        
        var response = await purchaseResponse;
        var result = await response.Content.ReadFromJsonAsync<Purchase>();
        return result;
    }
    
    public async Task<CustomerListResponse> Exchange(string dealerId, string receiverId, int amount = 100)
    {
        var dealer = await _customerService.GetItemById(dealerId);
        var receiver = await _customerService.GetItemById(receiverId);
        
        if (amount < 0)
            throw new Exception($"Invalid ECoins amount! Value cannot be less than zero!");
        
        if (dealer.ECoins < amount)
            throw new Exception($"Insufficient ECoins amount! Cannot send {amount} ECoins from {dealerId} to {receiverId}");
        
        dealer.ECoins -= amount;
        receiver.ECoins += amount;
        var dealerTx = _customerService.Update(dealer);
        var receiverTx = _customerService.Update(receiver);
        await Task.WhenAll(dealerTx, receiverTx);
        
        var result = await _customerService.GetExchangePair(dealerId, receiverId);
        return result;
    }
}