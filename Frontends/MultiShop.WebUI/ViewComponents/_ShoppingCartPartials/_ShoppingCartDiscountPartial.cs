using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Basket;
using MultiShop.DTOs.DTOs.Discount;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Basket;

namespace MultiShop.WebUI.ViewComponents._ShoppingCartPartials
{
    public class _ShoppingCartDiscountPartial:ViewComponent
    {
        private readonly IBasketService basketService;
        string urlBasket = "";
        public _ShoppingCartDiscountPartial(IBasketService basketService,IConfiguration configuration)
        {
            urlBasket = configuration["ServiceUrl:Basket"];
            this.basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            if (TempData["Total"] ==null)
            {
                BasketTotalDTO totaBasket = await basketService.GetBasketTotalAsync(urlBasket, HttpContext.Request.Cookies["AccesToken"]);
                if (totaBasket != null)
                {
                    ResultTotalDTO total = new ResultTotalDTO
                    {
                        Subtotal = totaBasket.TotalPrice,
                        Shipping = totaBasket.Baskets.Count * 2,
                        Total = totaBasket.TotalPrice + (totaBasket.Baskets.Count * 2),
                        DiscountTotal = 0
                    };
                    TempData["Total"] = total;
                }
            }

            return View();
        }
    }
}
