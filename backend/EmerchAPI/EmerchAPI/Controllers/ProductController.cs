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
        var result = new List<Product>();
        result.AddRange(Enumerable.Range(1, 4).Select(index => new Product()
            {
                Id = Guid.NewGuid(),
                Title = $"Cap {index}",
                Description = $"Cap description {index}",
                AvailableAmount = 124 + index,
                DiscountAvailable = 10 + index,
                SaleDiscount = false,
                ImageUrl = $"https://cdn.nakodeelee.ru/content/cap/{index}.png",
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
            .ToArray());
        result.AddRange(Enumerable.Range(1, 4).Select(index => new Product()
            {
                Id = Guid.NewGuid(),
                Title = $"Hoodie {index}",
                Description = $"Hoodie description {index}",
                AvailableAmount = 124 + index,
                DiscountAvailable = 10 + index,
                SaleDiscount = false,
                ImageUrl = $"https://cdn.nakodeelee.ru/content/hoodie/{index}.png",
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
            .ToArray());
        result.AddRange(Enumerable.Range(1, 4).Select(index => new Product()
            {
                Id = Guid.NewGuid(),
                Title = $"Tee {index}",
                Description = $"Tee description {index}",
                AvailableAmount = 124 + index,
                DiscountAvailable = 10 + index,
                SaleDiscount = false,
                ImageUrl = $"https://cdn.nakodeelee.ru/content/tee/{index}.png",
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
            .ToArray());

        return result;
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
            ImageUrl = "https://cdn.nakodeelee.ru/content/tee/{index}.png",
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