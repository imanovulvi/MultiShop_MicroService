using MultiShop.DTOs.DTOs.Catalog.Product;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog
{
    public interface IProductService:IHttpClientService
    {
        Task<List<ResultProductDTO>> GetProductsByCategoryIdAsync(string url, string categoryId, string header = null);
    }
}
