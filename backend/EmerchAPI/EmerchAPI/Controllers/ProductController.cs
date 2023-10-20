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
    public IEnumerable<Product> GetProducts()
    {
        return Enumerable.Range(1, 5).Select(index => new Product()
            {
                Id = Guid.NewGuid(),
                Title = $"Product {index}",
                Description = $"Product description {index}",
                AvailableAmount = 124 + index,
                DiscountAvailable = 10 + index,
                SaleDiscount = false,
                ProductContents = new List<ProductContent>()
                {
                    new()
                    {
                        ContentPercentage = 10 + index,
                        ContentName = $"Poliester {index}"
                    }
                }
            })
            .ToArray();
    }
}