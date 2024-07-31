namespace MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog
{
    public interface IProductDetailService:IHttpClientService
    {
        Task<T> GetDetailProductById<T>(string url, string productId, string header = null) where T : class;
    }
}
