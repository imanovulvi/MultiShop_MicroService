using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Comment;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _DetailReviewsPartial:ViewComponent
    {

        string url = "";
    
        HttpClient httpClient;

        public _DetailReviewsPartial(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Comment"];
         

            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.id is not null)
            {
            https://localhost:7207/api/Comment/GetCommentsProductById=669793288c396c08bdd22fc5
                HttpResponseMessage response = await httpClient.GetAsync(url + "/GetCommentsProductById?productId=" + ViewBag.id);
                if (response.IsSuccessStatusCode)
                {
                  return  View(JsonConvert.DeserializeObject<List<ResultCommentDTO>>(await response.Content.ReadAsStringAsync()));

                }

            }
            return View();
        }
    }
}
