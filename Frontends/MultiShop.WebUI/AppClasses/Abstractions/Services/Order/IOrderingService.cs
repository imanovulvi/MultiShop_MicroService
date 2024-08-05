using MultiShop.DTOs.DTOs.Order.Ordering;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Order
{
    public interface IOrderingService:IHttpClientService
    {
        Task<List<ResultOrderingDTO>> GetByUserIdAsync(string url, string userId, string header = null);
    }
}
