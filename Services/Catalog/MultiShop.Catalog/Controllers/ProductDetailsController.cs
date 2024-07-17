using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDetails;
using MultiShop.Catalog.Services.ProductDetails;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductDetailsService productDetails;

        public ProductDetailsController(IMapper mapper, IProductDetailsService ProductDetails)
        {
            this.mapper = mapper;
            this.productDetails = ProductDetails;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await productDetails.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await productDetails.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDetailsDTO create)
        {
            await productDetails.CreateAsync(create);
            return Ok("Elave edildi");
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDetailsDTO update)
        {
            await productDetails.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await productDetails.Delete(id);
            return Ok("silindi");
        }
    }
}
