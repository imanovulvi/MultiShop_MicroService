using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.About;
using Newtonsoft.Json;

namespace MultiShop.WebUI._LayoutPartials.ViewComponents
{
    public class _FooterPartial:ViewComponent
    {
        string url = "";

        HttpClient httpClient;

        public _FooterPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:About"];

            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<ResultAboutDTO>>(await response.Content.ReadAsStringAsync()));

            }
            return View();

        }
    }
}
