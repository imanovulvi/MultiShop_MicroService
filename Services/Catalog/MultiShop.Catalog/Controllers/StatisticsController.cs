using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Entitys;
using MultiShop.Catalog.Services.Statistics;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryCount()
        {

            return Ok(await statisticsService.CategoryCountAsync());
        }

        [HttpGet]
        public async Task<IActionResult> BrandCount()
        {

            return Ok(await statisticsService.BrandCountAsync());
        }
        [HttpGet]
        public async Task<IActionResult> ProductCount()
        {

            return Ok(await statisticsService.ProductCountAsync());
        }


        [HttpGet]
        public async Task<IActionResult> MaxPriceProductName()
        {

            return Ok(await statisticsService.MaxPriceProductNameAsync());
        }
        [HttpGet]
        public async Task<IActionResult> MinPriceProductName()
        {

            return Ok(await statisticsService.MinPriceProductNameAsync());
        }
    }
}
