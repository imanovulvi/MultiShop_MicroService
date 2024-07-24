using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MultiShop.DTOs.DTOs.Catalog.Category;
using MultiShop.DTOs.DTOs.Catalog.Product;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly string url;
        private readonly string urlCategory;
        private readonly HttpClient httpClient;

        public ProductController(IConfiguration configuration, IHttpClientFactory httpClient)
        {

            url = configuration["ServiceUrl:Catalog:Product"];
            urlCategory = configuration["ServiceUrl:Catalog:Category"];
            this.httpClient = httpClient.CreateClient();
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Product";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product list";
            HttpResponseMessage response = await httpClient.GetAsync(url + "/Get");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return View(JsonConvert.DeserializeObject<List<ResultProductDTO>>(json));
            }


            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {

            HttpResponseMessage response = await httpClient.DeleteAsync(url + "/Delete?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();

        }

        public async Task<IActionResult> Create()
        {

            HttpResponseMessage responseMessage = await httpClient.GetAsync(urlCategory + "/Get");
            if (responseMessage.IsSuccessStatusCode)
            {

                ViewBag.categorys = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO create)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url + "/Create", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();

        }

        public async Task<IActionResult> Update(string id)
        {

            HttpResponseMessage responseCategorys = await httpClient.GetAsync(urlCategory + "/Get");
            List<ResultCategoryDTO> categorys = null;
            if (responseCategorys.IsSuccessStatusCode)
            {

                ViewBag.categorys = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(await responseCategorys.Content.ReadAsStringAsync());
            }
            HttpResponseMessage responseProduct = await httpClient.GetAsync(url + "/GetById?id=" + id);

            ResultProductDTO productDTO = null;
            if (responseProduct.IsSuccessStatusCode)
            {
                productDTO = JsonConvert.DeserializeObject<ResultProductDTO>(await responseProduct.Content.ReadAsStringAsync());


            }
            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultProductDTO update)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(update), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(url + "/Update", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();
        }

    }
}
