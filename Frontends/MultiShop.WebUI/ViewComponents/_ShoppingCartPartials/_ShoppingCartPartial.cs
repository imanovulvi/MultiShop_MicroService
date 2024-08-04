using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Basket;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Basket;

namespace MultiShop.WebUI.ViewComponents._ShoppingCartPartials
{
    public class _ShoppingCartPartial:ViewComponent
    {
        string urlBasket = "";
        private readonly IBasketService basketService;
        private readonly IConfiguration configuration;

        public _ShoppingCartPartial(IBasketService basketService, IConfiguration configuration)
        {
            this.basketService = basketService;
            urlBasket = configuration["ServiceUrl:Basket"];
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
             return View(await basketService.GetBasketTotalAsync(urlBasket, HttpContext.Request.Cookies["AccesToken"]));
        }
    }
}
