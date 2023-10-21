using EmerchAPI.Services.Abstraction;

namespace EmerchAPI.Services;

public class YooMoneyService : IYooMoneyService
{
    private readonly HttpClient _httpClient;
    public YooMoneyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}