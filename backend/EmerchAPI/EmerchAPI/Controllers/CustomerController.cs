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

    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
        return Enumerable.Range(1, 5).Select(index => new Customer
            {
                Id = Guid.NewGuid(),
                Nickname = "@username",
                FirstName = "John",
                LastName = "Doe",
                ThumbnailUrl = "https://emerch.ru/content/pictures/1/1.png",
                ECoins = index,
                Products = new List<Product>()
                {
                    new()
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
                    }
                },
            })
            .ToArray();
    }
}