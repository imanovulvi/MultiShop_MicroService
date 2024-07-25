using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Brand;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _BreadPartial : ViewComponent
    {
        string url = "";

        HttpClient httpClient;

        public _BreadPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Brand"];

            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<ResultBrandDTO>>(await response.Content.ReadAsStringAsync()));

            }
            return View();

        }
    }
}
