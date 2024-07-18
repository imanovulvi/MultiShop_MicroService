using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Create
{
    public class CreateOrderingCommandHandler:IRequestHandler<CreateOrderingCommandRequest>
    {
        private readonly IRepository<ET.Ordering> repository;

        public CreateOrderingCommandHandler(IRepository<ET.Ordering> repository)
        {
            this.repository = repository;
        }

      
        public async Task Handle(CreateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            ET.Ordering entity = new ET.Ordering()
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,

            };

            await repository.AddAsync(entity);
        }
    }
}
