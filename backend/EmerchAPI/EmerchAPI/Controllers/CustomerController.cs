using EmerchAPI.Models;
using EmerchAPI.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EmerchAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;

    public CustomerController(
        ILogger<CustomerController> logger, 
        ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ListResponse<Customer>> GetCustomers() => await _customerService.GetItems();

    [HttpGet("{userId}")]
    public async Task<Customer> GetCustomerById([FromRoute] string userId) => await _customerService.GetItemById(userId);
    
    [HttpDelete("{CustomerCode}")]
    public async Task<Customer> DeleteCustomer([FromRoute] string userId) => await _customerService.Delete(userId);
    
    [HttpPost]
    public async Task<Customer> CreateCustomer([FromBody] Customer customer) => await _customerService.Create(customer);

    [HttpPut]
    public async Task<Customer> UpdateCustomer([FromBody] Customer customer) => await _customerService.Update(customer);
}