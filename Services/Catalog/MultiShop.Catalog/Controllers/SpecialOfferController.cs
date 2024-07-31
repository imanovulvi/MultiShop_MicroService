using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.SpecialOffer;
using MultiShop.Catalog.Services.SpecialOffer;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISpecialOfferService SpecialOffer;

        public SpecialOfferController(IMapper mapper, ISpecialOfferService SpecialOffer)
        {
            this.mapper = mapper;
            this.SpecialOffer = SpecialOffer;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await SpecialOffer.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await SpecialOffer.GetByIdAsync(id));
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecialOfferDTO create)
        {
            await SpecialOffer.CreateAsync(create);
            return Ok("Elave edildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSpecialOfferDTO update)
        {
            await SpecialOffer.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await SpecialOffer.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
