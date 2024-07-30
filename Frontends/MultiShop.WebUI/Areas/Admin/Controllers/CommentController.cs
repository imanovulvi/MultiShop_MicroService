using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Comment;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CommentController : Controller
    {
        private readonly string url;
        private readonly HttpClient httpClient;

        public CommentController(IConfiguration configuration, IHttpClientFactory httpClient)
        {

            url = configuration["ServiceUrl:Comment"];
            this.httpClient = httpClient.CreateClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //https://localhost:7207/api/Comment/Get
            ViewBag.v0 = "Comment";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comment";
            ViewBag.v3 = "Comment list";
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return View(JsonConvert.DeserializeObject<List<ResultCommentDTO>>(json));
            }


            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
     
        public async Task<IActionResult> Delete(string id)
        {


            HttpResponseMessage response = await httpClient.DeleteAsync(url + "/Delete?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Comment/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetById?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<UpdateCommentDTO>(json));
            }


            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateCommentDTO CommentDTO)
        {

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(CommentDTO), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(url + "/Update", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Comment/Index");
            }


            return View();

        }

    }

}