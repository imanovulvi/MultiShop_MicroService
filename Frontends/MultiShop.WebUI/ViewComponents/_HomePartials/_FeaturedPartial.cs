using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Featured;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _FeaturedPartial : ViewComponent
    {
        string url = "";

        HttpClient httpClient;

        public _FeaturedPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Featured"];

            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<ResultFeaturedDTO>>(await response.Content.ReadAsStringAsync()));

            }
            return View();

        }
    }
}
