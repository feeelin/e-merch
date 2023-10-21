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

    public ProductController(
        ILogger<ProductController> logger, 
        IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public async Task<ProductListResponse> GetProducts() => await _productService.GetItems();

    [HttpGet("{productCode}")]
    public async Task<Product> GetProductById([FromRoute] string productCode) => await _productService.GetItemById(productCode);
    
    [HttpDelete("{productCode}")]
    public async Task<Product> DeleteProduct([FromRoute] string productCode) => await _productService.Delete(productCode);
    
    [HttpPost]
    public async Task<Product> CreateProduct([FromBody] Product product) => await _productService.Create(product);

    [HttpPut]
    public async Task<Product> UpdateProduct([FromBody] Product product) => await _productService.Update(product);
}