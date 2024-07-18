using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Create;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Remove;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Update;
using MultiShop.Order.Application.Features.Queries.OrderDetail.GetAll;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await mediator.Send(new GetAllOrderDetailQueryRequest());
            return Ok(list);

        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Elave olundu");

        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("yenilendi");

        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveOrderDetailCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Silindi");

        }
    }
}
