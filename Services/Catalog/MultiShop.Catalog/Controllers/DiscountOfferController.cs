using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.DiscountOffer;
using MultiShop.Catalog.Services.DiscountOffer;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountOfferController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDiscountOfferService discountOffer;

        public DiscountOfferController(IMapper mapper, IDiscountOfferService DiscountOffer)
        {
            this.mapper = mapper;
            this.discountOffer = DiscountOffer;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await discountOffer.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await discountOffer.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountOfferDTO create)
        {
            await discountOffer.CreateAsync(create);
            return Ok("Elave edildi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDiscountOfferDTO update)
        {
            await discountOffer.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await discountOffer.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
