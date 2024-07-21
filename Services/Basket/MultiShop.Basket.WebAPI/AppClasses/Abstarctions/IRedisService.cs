using MultiShop.Basket.WebAPI.DTOs;

namespace MultiShop.Basket.WebAPI.AppClasses.Abstarctions
{
    public interface IRedisService
    {
        Task<T> GetAsync<T>(string key);
        Task<bool> SetAsync<T>(string key, T value);
        Task<bool> DeleteAsync(string key);
    }
}
