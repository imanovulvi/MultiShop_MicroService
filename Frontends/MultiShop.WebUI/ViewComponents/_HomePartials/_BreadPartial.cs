using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Brand;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _BreadPartial : ViewComponent
    {
        private readonly IBrandService brandService;
        string url = "";


        public _BreadPartial(IBrandService brandService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Brand"];

            
            this.brandService = brandService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await brandService.GetAllAsync<ResultBrandDTO>(url));
        }
    }
}
