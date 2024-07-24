using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.FeatureSlider;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        string url = "";
        HttpClient httpClient;

        public FeatureSliderController(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:FeatureSlider"];
            httpClient = httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> Index()
        {
           HttpResponseMessage response=await  httpClient.GetAsync(url+"/Get");
            if (response.IsSuccessStatusCode)
            {
              return View(JsonConvert.DeserializeObject<List<ResultFeatureSliderDTO>>(await response.Content.ReadAsStringAsync()));

            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureSliderDTO create)
        {

            StringContent stringConten = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url + "/Create", stringConten);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/FeatureSlider/Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {


            HttpResponseMessage response = await httpClient.DeleteAsync(url + "/Delete?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/FeatureSlider/Index");
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
                return View(JsonConvert.DeserializeObject<UpdateFeatureSliderDTO>(json));
            }


            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureSliderDTO categoryDTO)
        {

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(categoryDTO), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(url + "/Update", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/FeatureSlider/Index");
            }


            return View();

        }



    }
}
