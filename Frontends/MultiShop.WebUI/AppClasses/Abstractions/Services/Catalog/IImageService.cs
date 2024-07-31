namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog
{
    public interface IImageService:IHttpClientService
    {
        Task<bool> PostAsync(string url, string productId, IFormFileCollection formFiles, string header = null);
    }
}
