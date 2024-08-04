using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.DiscountOffer;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._HomePartials
{
    public class _DiscountOfferPartial : ViewComponent
    {
        private readonly IDiscountOfferService discountOfferService;
        string url = "";



        public _DiscountOfferPartial(IDiscountOfferService discountOfferService, IConfiguration configuration)
        {
            url = configuration["ServiceUrl:Catalog:DiscountOffer"];

            this.discountOfferService = discountOfferService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await discountOfferService.GetAllAsync<ResultDiscountOfferDTO>(url));
        }
    }
}
