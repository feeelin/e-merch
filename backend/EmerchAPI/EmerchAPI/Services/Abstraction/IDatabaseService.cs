using EmerchAPI.Models.Dtos;

namespace EmerchAPI.Services.Abstraction;

public interface IDatabaseService<TResult>
{
    public Task<TResult> GetItemById(string id);
    public Task<TResult> Create(TResult entity);
    public Task<TResult> Delete(string id);
    public Task<TResult> Update(TResult entity);
}