using MultiShop.DTOs.DTOs.Catalog.Product;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.AppClasses.Concretes.Services.Catalog
{
    public class ProductService:HttpClientService,IProductService
    {
        public async Task<List<ResultProductDTO>> GetProductsByCategoryIdAsync(string url, string categoryId, string header = null)
        {
            if (header != null)
                AddHeader(header);

            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetProductsCategoryById?categoryId=" + categoryId);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ResultProductDTO>>(json);
            }
            return null;
        }



    }
}
