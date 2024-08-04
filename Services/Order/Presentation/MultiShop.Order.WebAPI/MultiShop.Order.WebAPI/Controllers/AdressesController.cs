using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Adress.Create;
using MultiShop.Order.Application.Features.Commands.Adress.Remove;
using MultiShop.Order.Application.Features.Commands.Adress.Update;
using MultiShop.Order.Application.Features.Queries.Adress.GetAll;
using MultiShop.Order.Application.Features.Queries.Adress.GetByUserId;

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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var list= await mediator.Send(new GetAllAdressQueryRequest());
            return Ok(list);

        }
        [Authorize(Roles ="User")]
        [HttpGet]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            GetByUserIdQueryRequest request = new() {UserId=userId };
            return Ok(await mediator.Send(request));

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
