using EmerchAPI.Models.Dtos;
using EmerchAPI.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EmerchAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;
    private readonly IPurchaseService _purchaseService;

    public CustomerController(
        ILogger<CustomerController> logger, 
        ICustomerService customerService, 
        IPurchaseService purchaseService)
    {
        _logger = logger;
        _customerService = customerService;
        _purchaseService = purchaseService;
    }

    [HttpGet]
    public async Task<CustomerListResponse> GetCustomers() => await _customerService.GetItems();

    [HttpGet("{userId}")]
    public async Task<Customer> GetCustomerById([FromRoute] string userId) => await _customerService.GetItemById(userId);
    
    [Produces(typeof(Customer))]
    [HttpGet("telegram/{telegramId}")]
    public async Task<IActionResult> GetCustomerByTelegramId([FromRoute] string telegramId)
    {
        var result = await _customerService.GetItemByTelegramId(telegramId);
        if (result is null)
            return NotFound();

        return Ok(result);
    }
    
    [HttpGet("{userId}/history")]
    public async Task<PurchaseListDto> GetPurchases([FromRoute] string userId) => await _purchaseService.GetPurchaseHistory(userId);
    
    [HttpDelete("{userId}")]
    public async Task<Customer> DeleteCustomer([FromRoute] string userId) => await _customerService.Delete(userId);
    
    [HttpPost]
    public async Task<Customer> CreateCustomer([FromBody] Customer customer) => await _customerService.Create(customer);

    [HttpPut]
    public async Task<Customer> UpdateCustomer([FromBody] Customer customer) => await _customerService.Update(customer);
    
    [HttpPut("from/{dealerId}/to/{receiverId}/{amount}")]
    public async Task<CustomerListResponse> Exchange([FromRoute] string dealerId, [FromRoute] string receiverId,[FromRoute] int amount) =>
        await _purchaseService.Exchange(dealerId, receiverId, amount);
    
    [HttpPut("add/{amount}/to/{receiverId}")]
    public async Task<Customer> UpdateTokenAmount([FromRoute] string receiverId,[FromRoute] int amount) =>
        await _customerService.UpdateTokenAmount(receiverId, amount);
}