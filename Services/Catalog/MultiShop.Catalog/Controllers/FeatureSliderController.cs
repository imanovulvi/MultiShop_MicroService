using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.FeatureSlider;
using MultiShop.Catalog.Services.FeatureSlider;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeatureSliderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IFeatureSliderService FeatureSlider;

        public FeatureSliderController(IMapper mapper, IFeatureSliderService FeatureSlider)
        {
            this.mapper = mapper;
            this.FeatureSlider = FeatureSlider;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await FeatureSlider.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await FeatureSlider.GetByIdAsync(id));
        }
        [Authorize(Roles ="Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureSliderDTO create)
        {
            await FeatureSlider.CreateAsync(create);
            return Ok("Elave edildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureSliderDTO update)
        {
            await FeatureSlider.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await FeatureSlider.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
