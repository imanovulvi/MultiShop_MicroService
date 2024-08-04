using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.DTOs.Discount;
using MultiShop.Discount.Services.Discount;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService discountService;

        public DiscountsController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
        
           return Ok( await discountService.GetAllAsync());

        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {

            return Ok(await discountService.GetByIdAsync(id));

        }
        [HttpGet]
        public async Task<IActionResult> GetByCode(string code)
        {
            return Ok(await discountService.GetByCodeAsync(code));
        }

        [HttpGet]
        public async Task<IActionResult> GetByCodeIsActive(string code)
        {
            ResultDiscountDTO result = await discountService.GetByCodeAsync(code);
            if (result is not null)
                if (result.IsDelete && result.ValidDate > DateTime.UtcNow)
                {
                    return Ok(result);
                }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountDTO createDiscountDTO)
        {
            await discountService.CreateAsync(createDiscountDTO);
            return Ok("Elave olundu");

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDiscountDTO updateDiscountDTO)
        {
            await discountService.Update(updateDiscountDTO);
            return Ok("yenilendi");

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await discountService.DeleteAsync(id);
            return Ok("silindi");

        }

    }
}
