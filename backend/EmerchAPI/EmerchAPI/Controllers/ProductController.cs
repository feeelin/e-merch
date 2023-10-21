using EmerchAPI.Models.Dtos;
using EmerchAPI.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EmerchAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;
    private readonly IPurchaseService _purchaseService;

    public ProductController(
        ILogger<ProductController> logger, 
        IProductService productService, 
        IPurchaseService purchaseService)
    {
        _logger = logger;
        _productService = productService;
        _purchaseService = purchaseService;
    }

    [HttpGet]
    public async Task<ProductListResponse> GetProducts() => await _productService.GetItems();

    [HttpGet("{productId}")]
    public async Task<Product> GetProductById([FromRoute] string productId) => await _productService.GetItemById(productId);
    
    [HttpDelete("{productId}")]
    public async Task<Product> DeleteProduct([FromRoute] string productId) => await _productService.Delete(productId);
    
    [HttpPost]
    public async Task<Product> CreateProduct([FromBody] Product product) => await _productService.Create(product);

    [HttpPut]
    public async Task<Product> UpdateProduct([FromBody] Product product) => await _productService.Update(product);
    
    [HttpPut("{userId}/purchase/{productId}")]
    public async Task<Purchase> PurchaseProduct([FromRoute] string userId, string productId) => await _purchaseService.Purchase(userId, productId);
}