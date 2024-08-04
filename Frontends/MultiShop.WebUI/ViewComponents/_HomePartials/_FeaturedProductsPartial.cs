using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Product;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _FeaturedProductsPartial : ViewComponent
    {
        private readonly IProductService productService;
        string url = "";

        public _FeaturedProductsPartial(IProductService productService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Product"];

            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await productService.GetAllAsync<ResultProductDTO>(url));

        }
    }
}
