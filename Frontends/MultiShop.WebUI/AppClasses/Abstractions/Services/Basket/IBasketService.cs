using MultiShop.DTOs.DTOs.Basket;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Basket
{
    public interface IBasketService:IHttpClientService
    {
        Task<BasketTotalDTO> GetBasketTotalAsync(string url, string header);
    }
}
