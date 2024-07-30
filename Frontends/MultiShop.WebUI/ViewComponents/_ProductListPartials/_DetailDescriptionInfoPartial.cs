using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.ProductDetails;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _DetailDescriptionInfoPartial:ViewComponent
    {
        string url = "";

        HttpClient httpClient;

        public _DetailDescriptionInfoPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:ProductDetail"];


            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.id is not null)
            {

                HttpResponseMessage response = await httpClient.GetAsync(url + "/GetDetailProductById?productId=" + ViewBag.id);
                if (response.IsSuccessStatusCode)
                {
                  return View(JsonConvert.DeserializeObject<ResultProductDetailsDTO>(await response.Content.ReadAsStringAsync()));

                }


            }
            return View();
        }
    }
}
