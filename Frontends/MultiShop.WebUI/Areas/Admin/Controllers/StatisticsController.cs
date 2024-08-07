using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOs.DTOs.Catalog.Statistic;
using MultiShop.WebUI.AppClasses.Abstractions.Services.Statistic;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticService statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }
        public async Task<IActionResult> Index()
        {
            ResultStatisticDTO resultStatistic = new() { 
            BrandCount= await statisticService.BrandCountAsync(),
            CategoryCount= await statisticService.CategoryCountAsync(),
            ProductCount= await statisticService.ProductCountAsync(),
            MaxPriceProductName= await statisticService.MaxPriceProductNameAsync(),
            MinPriceProductName= await statisticService.MinPriceProductNameAsync()
            };

            return View(resultStatistic);
        }
    }
}
