using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Adress.Create;
using MultiShop.Order.Application.Features.Commands.Adress.Remove;
using MultiShop.Order.Application.Features.Commands.Adress.Update;
using MultiShop.Order.Application.Features.Queries.Adress.GetAll;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdressesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var list= await mediator.Send(new GetAllAdressQueryRequest());
            return Ok(list);

        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateAdressCommandRequest request)
        {
           await mediator.Send(request);
            return Ok("Elave olundu");

        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateAdressCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("yenilendi");

        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveAdressCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Silindi");

        }
    }
}
