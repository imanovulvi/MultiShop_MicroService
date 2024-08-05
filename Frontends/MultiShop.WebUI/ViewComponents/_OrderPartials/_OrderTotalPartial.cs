using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Basket;
using MultiShop.DTOs.DTOs.Discount;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Basket;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents._OrderPartials
{
    public class _OrderTotalPartial : ViewComponent
    {
        private readonly IBasketService basketService;
        string urlBasket = "";
        public _OrderTotalPartial(IBasketService basketService, IConfiguration configuration)
        {
            urlBasket = configuration["ServiceUrl:Basket"];
            this.basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResultTotalDTO totaBasket = JsonConvert.DeserializeObject<ResultTotalDTO>(HttpContext.Request.Cookies["BasketTotal"]);

                if (totaBasket != null)
                    ViewBag.total = totaBasket;
                
            

            return View();
        }
    }
}
