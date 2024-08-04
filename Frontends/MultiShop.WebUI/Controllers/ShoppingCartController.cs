using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Basket;
using MultiShop.DTOs.DTOs.Catalog.Product;
using MultiShop.DTOs.DTOs.Discount;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Basket;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Catalog;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Discount;
using Newtonsoft.Json;


namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService productService;
        private readonly IBasketService basketService;
        private readonly IDiscountService discountService;
        string urlDiscount = "";
        string urlProduct = "";
        string urlBasket = "";
        public ShoppingCartController(IDiscountService discountService,IProductService productService, IBasketService basketService, IConfiguration configuration)
        {
            this.discountService = discountService;
            urlDiscount = configuration["ServiceUrl:Discount"];
            this.productService = productService;
            this.basketService = basketService;
            urlProduct = configuration["ServiceUrl:Catalog:Product"];
            urlBasket = configuration["ServiceUrl:Basket"];
        }


        public IActionResult Index()
        {
            if (TempData["Total"] != null)
                TempData["Total"] = JsonConvert.DeserializeObject<ResultTotalDTO>(TempData["Total"].ToString());
            
            return View();
        }

        public async Task<IActionResult> AddBasket(string productId)
        {
            var product = await productService.GetByIdAsync<ResultProductDTO>(urlProduct, productId);

            var basketTotal = await basketService.GetBasketTotalAsync(urlBasket, HttpContext.Request.Cookies["AccesToken"]);

            if (basketTotal is null)
            {
                basketTotal = new BasketTotalDTO()
                {
                    Baskets = new List<BasketDTO>
                    {
                        new BasketDTO()
                            {
                    ProductId = product.Id,
                    Price = product.Price,
                    ProductImage = product.ImageUrl,
                    ProductName = product.Name,
                    Quantity = 1

                      }
                    }
                };
            }
            else
            {
                basketTotal.Baskets.Add(new BasketDTO()
                {
                    ProductId = product.Id,
                    Price = product.Price,
                    ProductImage = product.ImageUrl,
                    ProductName = product.Name,
                    Quantity = 1

                });
                await basketService.DeleteAsync(urlBasket, basketTotal.UserId);
            }

            await basketService.PostAsync(urlBasket, basketTotal, HttpContext.Request.Cookies["AccesToken"]);
            return Redirect("/ShoppingCart/Index");

        }

        
        public async Task<IActionResult> RemoveBasket(string productId)
        {

            var basketTotal = await basketService.GetBasketTotalAsync(urlBasket, HttpContext.Request.Cookies["AccesToken"]);

            basketTotal.Baskets.Remove(basketTotal.Baskets.FirstOrDefault(x => x.ProductId == productId));

            await basketService.DeleteAsync(urlBasket, basketTotal.UserId);

            await basketService.PostAsync(urlBasket, basketTotal, HttpContext.Request.Cookies["AccesToken"]);
            return Redirect("/ShoppingCart/Index");
        
        }

        public async Task<IActionResult> ApplyCoupon(string code)
        {
            ResultDiscountDTO discount = await discountService.GetByCodeActiveAsync(urlDiscount, code);
   
            if (discount != null)
            {
                BasketTotalDTO totaBasket = await basketService.GetBasketTotalAsync(urlBasket, HttpContext.Request.Cookies["AccesToken"]);



                ResultTotalDTO total = new ResultTotalDTO
                {
                    Subtotal = totaBasket.TotalPrice,
                    Shipping = totaBasket.Baskets.Count * 2,
                    Total = totaBasket.TotalPrice + (totaBasket.Baskets.Count * 2),
                  
                };

                total.DiscountTotal = total.Total - ((total.Total* discount.Rate)/100);
                TempData["Total"] = JsonConvert.SerializeObject(total);
            }
            return Redirect("/ShoppingCart/Index");
        }
    }
}
