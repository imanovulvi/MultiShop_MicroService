using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Catalog
{
    public class ProductDetailService:HttpClientService, IProductDetailService
    {

        public async Task<T> GetDetailProductById<T>(string url, string productId, string header = null) where T : class
        {

            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetDetailProductById?productId=" + productId);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(json);
            }
            return null;
        }
    }
}
