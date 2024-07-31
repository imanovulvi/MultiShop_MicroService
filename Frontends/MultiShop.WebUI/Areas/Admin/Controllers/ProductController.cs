using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MultiShop.DTOs.DTOs.Catalog.Category;
using MultiShop.DTOs.DTOs.Catalog.Image;
using MultiShop.DTOs.DTOs.Catalog.Product;
using MultiShop.DTOs.DTOs.Catalog.ProductDetails;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly string url;
        private readonly string urlCategory;
        private readonly string urlImage;
        private readonly string urlProductDetail;
        private readonly IProductService service;
        private readonly IProductDetailService productDetailService;
        private readonly IImageService imageService;

        //  private readonly HttpClient httpClient;

        public ProductController(IConfiguration configuration, IHttpClientFactory httpClient, IProductService service, IProductDetailService productDetailService, IImageService imageService)
        {

            url = configuration["ServiceUrl:Catalog:Product"];
            urlCategory = configuration["ServiceUrl:Catalog:Category"];
            urlImage = configuration["ServiceUrl:Catalog:Image"];
            urlProductDetail = configuration["ServiceUrl:Catalog:ProductDetail"];
           // this.httpClient = httpClient.CreateClient();
            this.service = service;
            this.productDetailService = productDetailService;
            this.imageService = imageService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Product";
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product list";

         var list=   await service.GetAllAsync<ResultProductDTO>(url);


            if (list !=null)
            {
                return View(list);
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {

            if (await service.DeleteAsync(url, id, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();

        }

        public async Task<IActionResult> Create()
        {
          var categorys=  await service.GetAllAsync<ResultCategoryDTO>(urlCategory);

            if (categorys is not null)
            {

                ViewBag.categorys = categorys;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO create)
        {

            if (await service.PostAsync(url, create, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();

        }

        public async Task<IActionResult> Update(string id)
        {
            var categorys = await service.GetAllAsync<ResultCategoryDTO>(urlCategory);


            List<ResultCategoryDTO> _categorys = null;
            if (categorys!=null)
            {

                ViewBag.categorys = categorys;
            }
            var products = await service.GetByIdAsync<ResultProductDTO>(url,id);

            ResultProductDTO productDTO = null;
            if (products is not null)
            {
                productDTO = products;


            }
            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ResultProductDTO update)
        {
            if (await service.PutAsync(url, update, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();
        }

        public async Task<IActionResult> GetImages(string id)
        {
            
            ViewBag.id = id;
            return View(await imageService.GetAllAsync<ResultImageDTO>(urlImage));
        }
        [HttpPost]
        public async Task<IActionResult> AddImages(IFormFileCollection formFiles, string productId)
        {
            
            if (await imageService.PostAsync(urlImage, productId, formFiles, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(string productId)
        {
          var productDetails= await productDetailService.GetDetailProductById<ResultProductDetailsDTO>(urlProductDetail,productId);

         

            ResultProductDetailsDTO productDTO = productDetails;


                if (productDTO is null)
                {
                    CreateProductDetailsDTO detailsDTO = new CreateProductDetailsDTO
                    {
                        ProductId = productId,
                        Descrtiption = "",
                        Info = ""

                    };
                   await service.PostAsync(urlProductDetail, detailsDTO, HttpContext.Request.Cookies["AccesToken"]);
                }
            
            return View(productDTO);
         
        }

        [HttpPost]
        public async Task<IActionResult> ProductDetailsUpdate(UpdateProductDetailsDTO updateDTO)
        {

            if (await service.PutAsync(urlProductDetail, updateDTO, HttpContext.Request.Cookies["AccesToken"]))
            {
                return Redirect("/Admin/Product/Index");
            }
            return View();
        }

    }
}
