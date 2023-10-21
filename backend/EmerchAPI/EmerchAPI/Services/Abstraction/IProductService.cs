using EmerchAPI.Models.Dtos;

namespace EmerchAPI.Services.Abstraction;

public interface IProductService : IDatabaseService<Product>
{
    public Task<ProductListResponse> GetItems();
}