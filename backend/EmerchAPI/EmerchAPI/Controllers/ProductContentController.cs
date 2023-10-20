using EmerchAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmerchAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductContentController : ControllerBase
{
    private readonly ILogger<ProductContentController> _logger;

    public ProductContentController(ILogger<ProductContentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<ProductContent> GetProductContents()
    {
        return Enumerable.Range(1, 5).Select(index => new ProductContent
            {
                ContentName = $"Poliester {index}",
                ContentPercentage = 10 + index
            })
            .ToArray();
    }
}