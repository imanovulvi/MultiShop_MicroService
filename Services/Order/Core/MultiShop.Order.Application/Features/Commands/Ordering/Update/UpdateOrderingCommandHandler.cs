using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Update
{
    public class UpdateOrderingCommandHandler:IRequestHandler<UpdateOrderingCommandRequest>
    {
        private readonly IRepository<ET.Ordering> repository;

        public UpdateOrderingCommandHandler(IRepository<ET.Ordering> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            ET.Ordering entity = new ET.Ordering()
            {
                Id = request.Id,
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,

            };
            await repository.UpdateAsync(entity);
        }
    }
}
