using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.Image;
using MultiShop.Catalog.Services.Image;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IImageService image;

        public ImageController(IMapper mapper, IImageService Image)
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

        [HttpGet]
        public async Task<IActionResult> GetImagesProductById([FromQuery] string productId)
        {

            return Ok(await image.GetImagesProductById(productId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFileCollection formCollection,string productId)
        {
           var a= Request.Form.Files;

            await image.CreateAsync(productId, Request.Form.Files);
            return Ok("Elave edildi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateImageDTO update)
        {
            await image.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await image.DeleteAsync(id);
            return Ok("silindi");
        }

    }
}
