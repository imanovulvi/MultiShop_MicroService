using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.Category;
using MultiShop.Catalog.Services.Category;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
 
    public class CategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICategoryService category;

        public CategoryController(IMapper mapper, ICategoryService category)
        {
            this.mapper = mapper;
            this.category = category;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await category.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            
            return Ok(await category.GetByIdAsync(id));
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO create)
        {
          await  category.CreateAsync(create);
            return Ok("Elave edildi");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDTO update)
        {
            await category.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]string id)
        {
            await category.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
