using MultiShop.DTOs.DTOs.Order.Adress;
using MultiShop.WebUI.AppClasses.Concretes;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Order
{
    public interface IAdressService:IHttpClientService
    {
        Task<ResultAdressDTO> GetByUserIdAsync(string url, string userId, string header = null);
    }
}
