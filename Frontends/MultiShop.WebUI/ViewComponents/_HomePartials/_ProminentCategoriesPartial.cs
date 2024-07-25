using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Category;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _ProminentCategoriesPartial : ViewComponent
    {
        string url = "";
        string urlSpecialOffer = "";
        HttpClient httpClient;

        public _ProminentCategoriesPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
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
