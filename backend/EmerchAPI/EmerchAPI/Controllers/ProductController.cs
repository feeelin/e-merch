using EmerchAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmerchAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return Enumerable.Range(1, 5).Select(index => new Product()
            {
                Id = Guid.NewGuid(),
                Title = $"Product {index}",
                Description = $"Product description {index}",
                AvailableAmount = 124 + index,
                DiscountAvailable = 10 + index,
                SaleDiscount = false,
                Cost = 1000 + index,
                ProductContents = new List<ProductContent>()
                {
                    new()
                    {
                        ContentPercentage = 10 + index,
                        ContentName = $"Poliester {index}"
                    },
                    new()
                    {
                        ContentPercentage = 10 + index,
                        ContentName = $"Poliester {index}"
                    },
                    new()
                    {
                        ContentPercentage = 10 + index,
                        ContentName = $"Poliester {index}"
                    }
                }
            })
            .ToArray();
    }
    
    [HttpGet("{productCode}")]
    public async Task<Product> GetProductById([FromRoute] string productCode)
    {
        return new Product()
        {
            Id = Guid.NewGuid(),
            Title = $"Product {productCode}",
            Description = $"Product description {productCode}",
            AvailableAmount = 124,
            DiscountAvailable = 10,
            SaleDiscount = false,
            Cost = 300,
            ProductContents = new List<ProductContent>()
            {
                new()
                {
                    ContentPercentage = 10,
                    ContentName = $"Poliester {productCode}"
                }
            }
        };
    }
}