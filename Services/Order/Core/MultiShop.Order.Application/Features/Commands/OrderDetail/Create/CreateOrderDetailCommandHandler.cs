using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Create
{
    public class CreateOrderDetailCommandHandler:IRequestHandler<CreateOrderDetailCommandRequest>
    {
        private readonly IRepository<ET.OrderDetail> repository;

        public CreateOrderDetailCommandHandler(IRepository<ET.OrderDetail> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            ET.OrderDetail entity = new ET.OrderDetail()
            {
                AmountPrice = request.AmountPrice,
                OrderingId = request.OrderingId,
                Price = request.Price,
                ProductId = request.ProductId,
                TotalPrice = request.TotalPrice
            };
            await repository.AddAsync(entity);
        }
    }
}
