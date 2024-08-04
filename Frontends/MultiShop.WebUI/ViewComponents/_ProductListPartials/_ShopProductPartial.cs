using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Image;
using MultiShop.DTOs.DTOs.Catalog.Product;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _ShopProductPartial:ViewComponent
    {
        private readonly IProductService productService;
        string url = "";
   
        HttpClient httpClient;

        public _ShopProductPartial(IProductService productService,IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Product"];
         

            httpClient = httpClientFactory.CreateClient();
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.id is not null)
            {
                return View(await productService.GetProductsByCategoryIdAsync(url, ViewBag.id));
               
            }
            else
            {
                return View(await productService.GetAllAsync<ResultProductDTO>(url));
            }
            return View();

        }
    }
}
