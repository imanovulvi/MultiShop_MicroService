using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.DiscountOffer;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountOfferController : Controller
    {
        private readonly string url;
        private readonly HttpClient httpClient;

        public DiscountOfferController(IConfiguration configuration, IHttpClientFactory httpClient)
        {

            url = configuration["ServiceUrl:Catalog:DiscountOffer"];
            this.httpClient = httpClient.CreateClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "DiscountOffer";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "DiscountOffer";
            ViewBag.v3 = "DiscountOffer list";
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return View(JsonConvert.DeserializeObject<List<ResultDiscountOfferDTO>>(json));
            }


            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountOfferDTO create)
        {

            StringContent stringConten = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url + "/Create", stringConten);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/DiscountOffer/Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {


            HttpResponseMessage response = await httpClient.DeleteAsync(url + "/Delete?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/DiscountOffer/Index");
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



                return View(JsonConvert.DeserializeObject<UpdateDiscountOfferDTO>(json));
            }


            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateDiscountOfferDTO discountOfferDTO)
        {

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(discountOfferDTO), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(url + "/Update", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/DiscountOffer/Index");
            }


            return View();

        }

    }
}

