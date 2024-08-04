using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Image;
using MultiShop.DTOs.DTOs.Catalog.Product;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;
using System.Security.Policy;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _DetailCarouselPartial : ViewComponent
    {
        private readonly IProductService productService;
        private readonly IImageService imageService;
        string url = "";
        string urlImage = "";
      

        public _DetailCarouselPartial(IProductService productService,IImageService ımageService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Product"];
            urlImage = configuration["ServiceUrl:Catalog:Image"];

        
            this.productService = productService;
            this.imageService = ımageService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.id is not null)
            {
                ViewBag.product = await productService.GetByIdAsync<ResultProductDTO>(url, ViewBag.id);
             
                return View(await imageService.GetImagesProductByIdAsync(urlImage, ViewBag.id));
            }
            return View();
        }
    }
}
