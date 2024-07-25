using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Product;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _FeaturedProductsPartial : ViewComponent
    {
        string url = "";

        HttpClient httpClient;

        public _FeaturedProductsPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Product"];
            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<ResultProductDTO>>(await response.Content.ReadAsStringAsync()));

            }
            return View();

        }
    }
}
