using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.DiscountOffer;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._LayoutPartials
{
    public class _DiscountOfferPartial:ViewComponent
    {
        string url = "";

        HttpClient httpClient;

        public _DiscountOfferPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:DiscountOffer"];

            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<ResultDiscountOfferDTO>>(await response.Content.ReadAsStringAsync()));

            }
            return View();

        }
    }
}
