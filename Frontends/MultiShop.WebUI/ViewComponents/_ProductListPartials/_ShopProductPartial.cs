using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Product;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _ShopProductPartial:ViewComponent
    {
        string url = "";

        HttpClient httpClient;

        public _ShopProductPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Product"];

            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.id is not null)
            {
                HttpResponseMessage response = await httpClient.GetAsync(url + "/GetProductCategoryById?categoryId=" + ViewBag.id);
                if (response.IsSuccessStatusCode)
                {
                    return View(JsonConvert.DeserializeObject<List<ResultProductDTO>>(await response.Content.ReadAsStringAsync()));

                }
            }
            else
            {
                HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
                if (response.IsSuccessStatusCode)
                {
                    return View(JsonConvert.DeserializeObject<List<ResultProductDTO>>(await response.Content.ReadAsStringAsync()));

                }
            }
            return View();

        }
    }
}
