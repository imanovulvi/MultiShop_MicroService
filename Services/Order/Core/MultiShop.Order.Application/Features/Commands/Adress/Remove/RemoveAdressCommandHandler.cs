using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Commands.Adress.Remove
{
    public class RemoveAdressCommandHandler:IRequestHandler<RemoveAdressCommandRequest>
    {
        private readonly IRepository<ET.Adress> repository;

        public RemoveAdressCommandHandler(IRepository<ET.Adress> repository)
        {
            this.repository = repository;
        }


        public async Task Handle(RemoveAdressCommandRequest request, CancellationToken cancellationToken)
        {
            ET.Adress entity = new ET.Adress
            {
                Id = request.Id
            };

            await repository.DeleteAsync(entity);
        }
    }
}
