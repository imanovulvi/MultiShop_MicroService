using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDetails;
using MultiShop.Catalog.Services.ProductDetails;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductDetailsService productDetails;

        public ProductDetailController(IMapper mapper, IProductDetailsService ProductDetails)
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

        [HttpGet]
        public async Task<IActionResult> GetDetailProductById([FromQuery] string productId)
        {
            return Ok(await productDetails.GetDetailProductByIdAsync(productId));
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDetailsDTO create)
        {
            await productDetails.CreateAsync(create);
            return Ok("Elave edildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDetailsDTO update)
        {
            await productDetails.UpdateAsync(update);
            return Ok("Yenilendi");
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await productDetails.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
