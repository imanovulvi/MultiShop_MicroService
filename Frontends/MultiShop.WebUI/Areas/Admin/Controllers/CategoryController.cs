using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MultiShop.DTOs.DTOs.Catalog.Category;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly string url;
        private readonly HttpClient httpClient;

        public CategoryController(IConfiguration configuration,IHttpClientFactory httpClient)
        {
      
            url = configuration["ServiceUrl:Catalog:Category"];
           this. httpClient = httpClient.CreateClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Category";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Category";
            ViewBag.v3 = "Category list";
            HttpResponseMessage response = await httpClient.GetAsync(url+"/Get");
            if (response.IsSuccessStatusCode)
            {
                string json =await response.Content.ReadAsStringAsync();
 
              return View(JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(json));
            }


            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO create)
        {

            StringContent stringConten = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url + "/Create", stringConten);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Category/Index");
            }
            return View();
        }

        public async  Task<IActionResult> Delete(string id)
        {


            HttpResponseMessage response = await httpClient.DeleteAsync(url + "/Delete?id="+ id);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Category/Index");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url + "/GetById?id="+id);
            if (response.IsSuccessStatusCode)
            {


                string json = await response.Content.ReadAsStringAsync();

               

                return View(JsonConvert.DeserializeObject<UpdateCategoryDTO>(json));
            }


            return View();

        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDTO categoryDTO)
        {

            StringContent stringContent =new StringContent(JsonConvert.SerializeObject(categoryDTO),Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(url + "/Update", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Category/Index");
            }


            return View();

        }

    }
}
