using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using DTO=MultiShop.Catalog.DTOs.Featured;
using MultiShop.Catalog.Services.Featured;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeaturedController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IFeaturedService Featured;

        public FeaturedController(IMapper mapper, IFeaturedService Featured)
        {
            this.mapper = mapper;
            this.Featured = Featured;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await Featured.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await Featured.GetByIdAsync(id));
        }



        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await Featured.DeleteAsync(id);
            return Ok("silindi");
        }

        [HttpPost]
        public async Task<IActionResult> Create(DTO.CreateFeaturedDTO create)
        {
            await Featured.CreateAsync(create);
            return Ok("Elave edildi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(DTO.UpdateFeaturedDTO update)
        {
            await Featured.UpdateAsync(update);
            return Ok("Yenilendi");
        }


    }
}
