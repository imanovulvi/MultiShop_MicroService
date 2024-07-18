using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET=MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Commands.Adress.Create
{
    public class CreateAdressCommandHandler:IRequestHandler<CreateAdressCommandRequest>
    {
        private readonly IRepository<ET.Adress> repository;

        public CreateAdressCommandHandler(IRepository<ET.Adress> repository)
        {
            this.repository = repository;
        }


        public async Task Handle(CreateAdressCommandRequest request, CancellationToken cancellationToken)
        {
            ET.Adress entity = new ET.Adress
            {
                City = request.City,
                UserId = request.UserId,
                Detail = request.Detail,
                Destrict = request.Destrict
            };
            var response = await repository.AddAsync(entity);
        }
    }
}
