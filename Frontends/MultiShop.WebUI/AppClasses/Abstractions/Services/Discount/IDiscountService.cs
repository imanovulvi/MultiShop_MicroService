using MultiShop.DTOs.DTOs.Discount;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Discount
{
    public interface IDiscountService:IHttpClientService
    {
        Task<ResultDiscountDTO> GetByCodeActiveAsync(string url, string code, string header=null);
    }
}
