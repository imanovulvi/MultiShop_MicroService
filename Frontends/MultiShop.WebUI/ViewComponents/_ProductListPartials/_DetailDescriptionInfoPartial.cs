using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.ProductDetails;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _DetailDescriptionInfoPartial:ViewComponent
    {
        private readonly IProductDetailService productDetailService;
        string url = "";



        public _DetailDescriptionInfoPartial(IProductDetailService productDetailService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:ProductDetail"];

            this.productDetailService = productDetailService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (ViewBag.id is not null)
            {
                return View(await productDetailService.GetDetailProductById<ResultProductDetailsDTO>(url, ViewBag.id));
            }
            return View();
        }
    }
}
