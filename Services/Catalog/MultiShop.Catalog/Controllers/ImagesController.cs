using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.Image;
using MultiShop.Catalog.Services.Image;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IImageService image;

        public ImagesController(IMapper mapper, IImageService Image)
        {
            this.mapper = mapper;
            this.image = Image;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await image.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await image.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateImageDTO create)
        {
            await image.CreateAsync(create);
            return Ok("Elave edildi");
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateImageDTO update)
        {
            await image.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await image.Delete(id);
            return Ok("silindi");
        }

    }
}
