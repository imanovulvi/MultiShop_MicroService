using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinesLayer.Abstractions;
using MultiShop.Cargo.DTOsLayer.DTOs.CargoDetail;
using MultiShop.Cargo.DTOsLayer.DTOs.CargoOperation;
using MultiShop.Cargo.EntitysLayer.Entitys;

namespace MultiShop.Cargo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService manager;

        public CargoOperationController(ICargoOperationService manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = manager.GetAll();
            List<GetCargoOperationDTO> dto = new List<GetCargoOperationDTO>();
            foreach (var item in entity)
            {
                dto.Add(new GetCargoOperationDTO
                {


                    Id = item.Id,
                    Barcode = item.Barcode,
                  CargoDate = item.CargoDate,
                  Description=item.Description
                 

                });


            }

            return Ok(dto);

        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var entity = manager.GetById(id);
            GetCargoOperationDTO dto = new GetCargoOperationDTO
            {
                Id = entity.Id,
                Barcode = entity.Barcode,
                CargoDate = entity.CargoDate,
                Description = entity.Description

            };

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult Create(CreateCargoOperationDTO request)
        {
            CargoOperation entity = new CargoOperation()
            {
            Barcode = request.Barcode,
            CargoDate = request.CargoDate,
            Description = request.Description,
            };
            manager.Create(entity);
            return Ok("Elave edildi");

        }

        [HttpPut]
        public IActionResult Update(UpdateCargoOperationDTO request)
        {
            CargoOperation entity = new CargoOperation()
            {
                Id=request.Id,
                Barcode = request.Barcode,
                CargoDate = request.CargoDate,
                Description = request.Description,

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
