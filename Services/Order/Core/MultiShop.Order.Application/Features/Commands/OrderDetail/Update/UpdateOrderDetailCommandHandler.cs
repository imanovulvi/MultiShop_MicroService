using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Update
{
    public class UpdateOrderDetailCommandHandler:IRequestHandler<UpdateOrderDetailCommandRequest>
    {
        private readonly IRepository<ET.OrderDetail> repository;

        public UpdateOrderDetailCommandHandler(IRepository<ET.OrderDetail> repository)
        {
            this.repository = repository;
        }

      

        public async Task Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            ET.OrderDetail entity = new ET.OrderDetail()
            {
                Id = request.Id,
                AmountPrice = request.AmountPrice,
                OrderingId = request.OrderingId,
                Price = request.Price,
                ProductId = request.ProductId,
                TotalPrice = request.TotalPrice
            };

            await repository.UpdateAsync(entity);
        }
    }
}
