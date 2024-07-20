using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinesLayer.Abstractions;
using MultiShop.Cargo.DTOsLayer.DTOs.CargoDetail;
using MultiShop.Cargo.EntitysLayer.Entitys;
using System.ComponentModel.Design;
using System.Reflection;

namespace MultiShop.Cargo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService manager;

        public CargoDetailController(ICargoDetailService manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var entity = manager.GetAll();
            List<GetCargoDetailDTO> dto=new List<GetCargoDetailDTO>();
            foreach (var item in entity)
            {
                dto.Add(new GetCargoDetailDTO {
                    Id=item.Id,
                   Barcode = item.Barcode,
                    CompanyId = item.CompanyId,
                    Receiver = item.Receiver,
                   Sender = item.Sender

                });

           
            }

          return Ok(dto);

        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var entity = manager.GetById(id);
            GetCargoDetailDTO dto = new GetCargoDetailDTO
            {
                Id = entity.Id,
                Barcode = entity.Barcode,
                CompanyId = entity.CompanyId,
                Receiver = entity.Receiver,
                Sender = entity.Sender

            };

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult Create(CreateCargoDetailDTO request)
        {
            CargoDetail entity = new CargoDetail() { 
            Barcode=request.Barcode,
            CompanyId=request.CompanyId,
            Receiver=request.Receiver,
            Sender = request.Sender
            
            };
            manager.Create(entity);
            return Ok("Elave edildi");

        }

        [HttpPut]
        public IActionResult Update(UpdateCargoDetailDTO request)
        {
            CargoDetail entity = new CargoDetail()
            {
                Id=request.Id,
                Barcode = request.Barcode,
                CompanyId = request.CompanyId,
                Receiver = request.Receiver,
                Sender = request.Sender

            };
            manager.Update(entity);
            return Ok("Yenilendi");

        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {

            manager.Delete(id);
            return Ok("silindi");

        }

    }
}
