using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Contact;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly string url;
        private readonly HttpClient httpClient;

        public ContactController(IConfiguration configuration, IHttpClientFactory httpClient)
        {

            url = configuration["ServiceUrl:Catalog:Contact"];
            this.httpClient = httpClient.CreateClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Contact";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Contact";
            ViewBag.v3 = "Contact list";
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return View(JsonConvert.DeserializeObject<List<ResultContactDTO>>(json));
            }


            return View();
        }
        
        public async Task<IActionResult> Delete(string id)
        {


            HttpResponseMessage response = await httpClient.DeleteAsync(url + "/Delete?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Contact/Index");
            }
            return View();

        }
    }
}
