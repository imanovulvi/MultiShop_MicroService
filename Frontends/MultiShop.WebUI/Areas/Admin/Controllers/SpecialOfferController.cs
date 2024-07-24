using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.SpecialOffer;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly string url;
        private readonly HttpClient httpClient;

        public SpecialOfferController(IConfiguration configuration, IHttpClientFactory httpClient)
        {

            url = configuration["ServiceUrl:Catalog:SpecialOffer"];
            this.httpClient = httpClient.CreateClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "SpecialOffer";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "SpecialOffer";
            ViewBag.v3 = "SpecialOffer list";
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return View(JsonConvert.DeserializeObject<List<ResultSpecialOfferDTO>>(json));
            }


            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecialOfferDTO create)
        {

            StringContent stringConten = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url + "/Create", stringConten);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/SpecialOffer/Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {


            HttpResponseMessage response = await httpClient.DeleteAsync(url + "/Delete?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/SpecialOffer/Index");
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



                return View(JsonConvert.DeserializeObject<UpdateSpecialOfferDTO>(json));
            }


            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateSpecialOfferDTO categoryDTO)
        {

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(categoryDTO), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(url + "/Update", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/SpecialOffer/Index");
            }


            return View();

        }

    }
}
