using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Featured;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _FeaturedPartial : ViewComponent
    {
        private readonly IFeaturedService featuredService;
        string url = "";



        public _FeaturedPartial(IFeaturedService featuredService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:Featured"];

            this.featuredService = featuredService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View(await featuredService.GetAllAsync<ResultFeaturedDTO>(url));

        }
    }
}
