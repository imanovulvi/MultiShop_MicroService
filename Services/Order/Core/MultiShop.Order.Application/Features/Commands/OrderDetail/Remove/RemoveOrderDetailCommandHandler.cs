using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Remove
{
    public class RemoveOrderDetailCommandHandler:IRequestHandler<RemoveOrderDetailCommandRequest>
    {
        private readonly IRepository<ET.OrderDetail> repository;

        public RemoveOrderDetailCommandHandler(IRepository<ET.OrderDetail> repository)
        {
            this.repository = repository;
        }


        public async Task Handle(RemoveOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            ET.OrderDetail entity = new ET.OrderDetail()
            {

                Id = request.Id
            };
            await repository.DeleteAsync(entity);
        }
    }
}
