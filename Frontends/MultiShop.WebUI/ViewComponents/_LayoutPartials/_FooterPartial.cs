using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.About;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI._LayoutPartials.ViewComponents
{
    public class _FooterPartial:ViewComponent
    {
        private readonly IAboutService aboutService;
        string url = "";



        public _FooterPartial(IAboutService aboutService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:About"];
            this.aboutService = aboutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await aboutService.GetAllAsync<ResultAboutDTO>(url));


        }
    }
}
