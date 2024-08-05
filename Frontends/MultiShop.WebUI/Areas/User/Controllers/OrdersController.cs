using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Order.Ordering;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Order;
using System.Security.Claims;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class OrdersController : Controller
    {
        private readonly IOrderingService orderingService;
        string urlOrdering = "";
        public OrdersController(IOrderingService orderingService,IConfiguration configuration)
        {
            this.orderingService = orderingService;
            urlOrdering = configuration["ServiceUrl:Order:Ordering"];
        }
        public async Task<IActionResult> Index()
        {
            Claim? claim = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            List<ResultOrderingDTO> result=await orderingService.GetByUserIdAsync(urlOrdering, claim.Value);
            return View(result);
        }
    }
}
