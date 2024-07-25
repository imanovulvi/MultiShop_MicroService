using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.Product;
using MultiShop.Catalog.Services.Product;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductService products;

        public ProductController(IMapper mapper, IProductService Product)
        {
            this.mapper = mapper;
            this.products = Product;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await products.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await products.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO create)
        {
            await products.CreateAsync(create);
            return Ok("Elave edildi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDTO update)
        {
            await products.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await products.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
