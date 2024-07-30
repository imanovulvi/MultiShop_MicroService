using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Image;
using MultiShop.DTOs.DTOs.Catalog.Product;
using Newtonsoft.Json;
using System.Security.Policy;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _DetailCarouselPartial : ViewComponent
    {
        string url = "";
        string urlImage = "";
        HttpClient httpClient;

        public _DetailCarouselPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Product"];
            urlImage = configuration["ServiceUrl:Catalog:Image"];

            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.id is not null)
            {

                HttpResponseMessage response = await httpClient.GetAsync(url + "/GetById?id=" + ViewBag.id);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.product = JsonConvert.DeserializeObject<ResultProductDTO>(await response.Content.ReadAsStringAsync());

                }


                HttpResponseMessage responseProduct = await httpClient.GetAsync(urlImage + "/GetImagesProductById?productId=" + ViewBag.id);


                if (responseProduct.IsSuccessStatusCode)
                {
                    var result = await responseProduct.Content.ReadAsStringAsync();
                    if (result != "[]")
                        return View(JsonConvert.DeserializeObject<List<ResultImageDTO>>(result));
                }


                

            }
            return View();
        }
    }
}
