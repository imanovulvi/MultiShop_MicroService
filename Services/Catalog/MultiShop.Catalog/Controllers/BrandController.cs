﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.Brand;
using MultiShop.Catalog.Services.Brand;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBrandService brand;

        public BrandController(IMapper mapper, IBrandService brand)
        {
            this.mapper = mapper;
            this.brand = brand;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await brand.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {

            return Ok(await brand.GetByIdAsync(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDTO create)
        {
            await brand.CreateAsync(create);
            return Ok("Elave edildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandDTO update)
        {
            await brand.UpdateAsync(update);
            return Ok("Yenilendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await brand.DeleteAsync(id);
            return Ok("silindi");
        }
    }
}
