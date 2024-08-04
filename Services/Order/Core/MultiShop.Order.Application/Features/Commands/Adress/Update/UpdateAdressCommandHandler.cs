using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Commands.Adress.Update
{
    public class UpdateAdressCommandHandler:IRequestHandler<UpdateAdressCommandRequest>
    {
        private readonly IRepository<ET.Adress> repository;

        public UpdateAdressCommandHandler(IRepository<ET.Adress> repository)
        {
            this.repository = repository;
        }



        public async Task Handle(UpdateAdressCommandRequest request, CancellationToken cancellationToken)
        {
            ET.Adress entity = new ET.Adress
            {
                Id = request.Id,
                City = request.City,
                UserId = request.UserId,
                Destrict = request.Destrict,
                Detail1 = request.Detail1,
                Detail2 = request.Detail2,
                Country = request.Country,
                ZipCode = request.ZipCode
            };
            await repository.UpdateAsync(entity);
        }
    }
}
