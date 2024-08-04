using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.WebAPI.AppClasses.Abstarctions;
using MultiShop.Basket.WebAPI.DTOs;
using System.Security.Claims;

namespace MultiShop.Basket.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IRedisService redisService;

        public BasketController(IRedisService redisService)
        {
            this.redisService = redisService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
           Claim? claim= Request.HttpContext.User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier);
            
            var baskets = await redisService.GetAsync<BasketTotalDTO>(claim.Value);
            return Ok(baskets);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BasketTotalDTO basket)
        {
            Claim claim = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            await redisService.SetAsync<BasketTotalDTO>(claim.Value, basket);
            return Ok("Elave olundu");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {

            await redisService.DeleteAsync(id);
            return Ok("Silindi");
        }


    }
}
