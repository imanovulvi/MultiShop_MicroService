using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MultiShop.DTOs.DTOs.Catalog.Category;
using MultiShop.DTOs.DTOs.Catalog.Image;
using MultiShop.DTOs.DTOs.Catalog.Product;
using MultiShop.DTOs.DTOs.Catalog.ProductDetails;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly string url;
        private readonly string urlCategory;
        private readonly string urlImage;
        private readonly string urlProductDetail;
        private readonly HttpClient httpClient;

        public ProductController(IConfiguration configuration, IHttpClientFactory httpClient)
        {

            url = configuration["ServiceUrl:Catalog:Product"];
            urlCategory = configuration["ServiceUrl:Catalog:Category"];
            urlImage = configuration["ServiceUrl:Catalog:Image"];
            urlProductDetail = configuration["ServiceUrl:Catalog:ProductDetail"];
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

        public async Task<IActionResult> GetImages(string id)
        {



            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddImages(IFormFileCollection formFiles, string productId)
        {
            var content = new MultipartFormDataContent();
            foreach (var file in formFiles)
            {

                var fileStream = file.OpenReadStream();

                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
                content.Add(fileContent, "file", file.FileName);
            }




            var response = await httpClient.PostAsync(urlImage + "/Create?productId=" + productId, content);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(string productId)
        {
            HttpResponseMessage responseProduct = await httpClient.GetAsync(urlProductDetail + "/GetDetailProductById?productId=" + productId);

            ResultProductDetailsDTO productDTO = null;
            if (responseProduct.IsSuccessStatusCode)
            {
                productDTO = JsonConvert.DeserializeObject<ResultProductDetailsDTO>(await responseProduct.Content.ReadAsStringAsync());

                if (productDTO is null)
                {
                    CreateProductDetailsDTO detailsDTO = new CreateProductDetailsDTO
                    {
                        ProductId = productId,
                        Descrtiption = "",
                        Info = ""

                    };
                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(detailsDTO), Encoding.UTF8, "application/json");


                    HttpResponseMessage responseCretaeProduct = await httpClient.PostAsync(urlProductDetail + "/Create", stringContent);
                }
            }
            return View(productDTO);

        }

        [HttpPost]
        public async Task<IActionResult> ProductDetailsUpdate(UpdateProductDetailsDTO updateDTO)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(updateDTO), Encoding.UTF8, "application/json");


            HttpResponseMessage response = await httpClient.PutAsync(urlProductDetail + "/Update", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();
        }

    }
}
