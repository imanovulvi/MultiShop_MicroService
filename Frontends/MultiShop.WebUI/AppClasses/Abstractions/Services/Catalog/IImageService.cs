using MultiShop.DTOs.DTOs.Catalog.Image;

namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog
{
    public interface IImageService:IHttpClientService
    {
        Task<List<ResultImageDTO>> GetImagesProductByIdAsync(string url, string productId, string header = null);
        Task<bool> PostAsync(string url, string productId, IFormFileCollection formFiles, string header = null);
    }
}
