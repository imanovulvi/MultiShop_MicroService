using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Category;
using Newtonsoft.Json;

namespace MultiShop.WebUI._LayoutPartials.ViewComponents
{
    public class _NavbarPartial:ViewComponent
    {
        string url = "";
        string urlSpecialOffer = "";
        HttpClient httpClient;

        public _NavbarPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:FeatureSlider"];
            urlSpecialOffer = configuration["ServiceUrl:Catalog:Category"];
            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseSpecialOffer = await httpClient.GetAsync(urlSpecialOffer + "/Get");
            if (responseSpecialOffer.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(await responseSpecialOffer.Content.ReadAsStringAsync()));

            }

            return View();

        }
    }
}
