using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinesLayer.Abstractions;
using MultiShop.Cargo.DTOsLayer.DTOs.Customer;
using MultiShop.Cargo.EntitysLayer.Entitys;

namespace MultiShop.Cargo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService manager;

        public CustomerController(ICustomerService manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = manager.GetAll();
            List<GetCustomerDTO> dto = new List<GetCustomerDTO>();
            foreach (var item in entity)
            {
                dto.Add(new GetCustomerDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    PhoneNo = item.PhoneNo,
                    City = item.City,
                    Adress=item.Adress

                });


            }

            return Ok(dto);

        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var entity = manager.GetById(id);
            GetCustomerDTO dto = new GetCustomerDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                PhoneNo = entity.PhoneNo,
                City = entity.City,
                Adress = entity.Adress

            };

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDTO request)
        {
            Customer entity = new Customer()
            {
             
                Name = request.Name,
                Surname = request.Surname,
                PhoneNo = request.PhoneNo,
                City = request.City,
                Adress = request.Adress

            };
            manager.Create(entity);
            return Ok("Elave edildi");

        }

        [HttpPut]
        public IActionResult Update(UpdateCustomerDTO request)
        {
            Customer entity = new Customer()
            {
                Id=request.Id,
                Name = request.Name,
                Surname = request.Surname,
                PhoneNo = request.PhoneNo,
                City = request.City,
                Adress = request.Adress

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
