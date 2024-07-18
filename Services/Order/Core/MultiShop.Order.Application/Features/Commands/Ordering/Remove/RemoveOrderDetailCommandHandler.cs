using MediatR;
using MultiShop.Order.Application.Features.Commands.OrderDetail.Remove;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ET = MultiShop.Order.Domain.Entitys;
namespace MultiShop.Order.Application.Features.Commands.Ordering.Remove
{
    public class RemoveOrderingCommandHandler:IRequestHandler<RemoveOrderDetailCommandRequest>
    {
        private readonly IRepository<ET.Ordering> repository;

        public RemoveOrderingCommandHandler(IRepository<ET.Ordering> repository)
        {
            this.repository = repository;
        }


        public async  Task Handle(RemoveOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            ET.Ordering entity = new ET.Ordering()
            {
                Id = request.Id
            };
            await repository.DeleteAsync(entity);
        }
    }
}
