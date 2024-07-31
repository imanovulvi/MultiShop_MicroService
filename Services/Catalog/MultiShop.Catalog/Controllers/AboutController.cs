using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.About;
using MultiShop.Catalog.Services.About;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAboutService About;

        public AboutController(IMapper mapper, IAboutService About)
        {
            this.mapper = mapper;
            this.About = About;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await About.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await About.GetByIdAsync(id));
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateAboutDTO create)
        {
            await About.CreateAsync(create);
            return Ok("Elave edildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDTO update)
        {
            await About.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await About.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
