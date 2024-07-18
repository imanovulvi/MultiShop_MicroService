using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Ordering.Create;
using MultiShop.Order.Application.Features.Commands.Ordering.Remove;
using MultiShop.Order.Application.Features.Commands.Ordering.Update;
using MultiShop.Order.Application.Features.Queries.Ordering.GetAll;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(list);

        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderingCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Elave olundu");

        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderingCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("yenilendi");

        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveOrderingCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Silindi");

        }
    }
}
