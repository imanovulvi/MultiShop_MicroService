using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Comment;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly HttpClient httpClient;
        string urlComment = "";
        public ProductListController(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            httpClient=httpClientFactory.CreateClient();
            urlComment = configuration["ServiceUrl:Comment"];
        }

        public IActionResult Index(string id)
        {
            ViewBag.Id = id;    
            return View();
        }

        public IActionResult Detail(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDTO dto)
        {
            dto.CreateDate = DateTime.Now;
            dto.Status = true;
            dto.Rating = 2;

            StringContent stringContent=new StringContent(JsonConvert.SerializeObject(dto),Encoding.UTF8,"application/json");
            HttpResponseMessage response=await httpClient.PostAsync(urlComment+"/Create", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductList");
            }
            return View();
        }
    }
}
