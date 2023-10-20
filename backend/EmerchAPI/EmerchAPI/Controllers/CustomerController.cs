using EmerchAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmerchAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{userId}")]
    public async Task<Customer> GetCustomer([FromRoute] string userId)
    {
        var result = new Customer()
        {
            Id = Guid.NewGuid(),
            Nickname = userId,
            FirstName = "John",
            LastName = "Doe",
            ThumbnailUrl = "https://emerch.nakodeelee.ru/content/pictures/1/1.png",
            ECoins = 100500,
            Products = new List<Product>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = $"Product 1",
                    Description = $"Product description 1",
                    AvailableAmount = 124,
                    DiscountAvailable = 10,
                    SaleDiscount = false,
                    ProductContents = new List<ProductContent>()
                    {
                        new()
                        {
                            ContentPercentage = 10,
                            ContentName = $"Poliester"
                        }
                    }
                }
            },
        };
        
        return result;
    }
}