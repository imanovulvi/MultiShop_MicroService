using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.FeatureSlider;
using MultiShop.DTOs.DTOs.Catalog.SpecialOffer;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._LayoutPartials
{
    public class _CarouselPartial : ViewComponent
    {
        string url = "";
        string urlSpecialOffer = "";
        HttpClient httpClient;

        public _CarouselPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:FeatureSlider"];
            urlSpecialOffer = configuration["ServiceUrl:Catalog:SpecialOffer"];
            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage responseSpecialOffer = await httpClient.GetAsync(urlSpecialOffer + "/Get");
            if (responseSpecialOffer.IsSuccessStatusCode)
            {
              ViewBag.specialOffer= JsonConvert.DeserializeObject<List<ResultSpecialOfferDTO>>(await responseSpecialOffer.Content.ReadAsStringAsync());

            }



            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<ResultFeatureSliderDTO>>(await response.Content.ReadAsStringAsync()));

            }
            return View();
       
        }
    }
}
