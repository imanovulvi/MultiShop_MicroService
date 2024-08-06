using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinesLayer.Abstractions;
using MultiShop.Cargo.DTOsLayer.DTOs.Company;
using MultiShop.Cargo.EntitysLayer.Entitys;

namespace MultiShop.Cargo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService manager;

        public CompanyController(ICompanyService manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = manager.GetAll();
            List<GetCompanyDTO> dto = new List<GetCompanyDTO>();
            foreach (var item in entity)
            {
                dto.Add(new GetCompanyDTO
                {
                    Id = item.Id,

                    Name = item.Name
                   

                });


            }

            return Ok(dto);

        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var entity = manager.GetById(id);
            GetCompanyDTO dto = new GetCompanyDTO
            {
                Id = entity.Id,

                Name = entity.Name

            };

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult Create(CreateCompanyDTO request)
        {
            Company entity = new Company()
            {
                Name = request.Name

            };
            manager.Create(entity);
            return Ok("Elave edildi");

        }

        [HttpPut]
        public IActionResult Update(UpdateCompanyDTO request)
        {
            Company entity = new Company()
            {
                Id = request.Id,

                Name = request.Name

            };
            manager.Update(entity);
            return Ok("Yenilendi");

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            manager.Delete(id);
            return Ok("silindi");

        }
    }
}
