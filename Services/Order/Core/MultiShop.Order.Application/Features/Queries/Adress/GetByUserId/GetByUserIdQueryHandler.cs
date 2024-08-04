using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Queries.Adress.GetByUserId
{
    internal class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQueryRequest, GetByUserIdQueryResponse>
    {
        private readonly IRepository<ET.Adress> repository;

        public GetByUserIdQueryHandler(IRepository<ET.Adress> repository)
        {
            this.repository = repository;
        }
        public async Task<GetByUserIdQueryResponse> Handle(GetByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
           ET.Adress adress= repository.Filter(x=>x.UserId==request.UserId).FirstOrDefault();
           
            return new ()
            {
                Id = adress.Id,
                UserId = adress.UserId,
                City = adress.City,
                Country = adress.Country,
                Destrict = adress.Destrict,
                Detail1 = adress.Detail1,
                Detail2 = adress.Detail2,
                ZipCode = adress.ZipCode

            };
        }
    }
}
