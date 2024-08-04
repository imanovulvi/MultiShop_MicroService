using MediatR;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Queries.Adress.GetAll
{
    public class GetAllAdressQueryHandler:IRequestHandler<GetAllAdressQueryRequest,List<GetAllAdressQueryResponse>>
    {
        private readonly IRepository<ET.Adress> repository;

        public GetAllAdressQueryHandler(IRepository<ET.Adress> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetAllAdressQueryResponse>> Handle(GetAllAdressQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await repository.GetAllAsync();

            List<GetAllAdressQueryResponse> response = new();
            foreach (var item in list)
            {
                response.Add(new GetAllAdressQueryResponse()
                {
                      Id = item.Id,
                    City = item.City,
                    UserId = item.UserId,
                    Destrict = item.Destrict,
                    Detail1 = item.Detail1,
                    Detail2 = item.Detail2,
                    Country = item.Country,
                    ZipCode = item.ZipCode
                });
            }

            return response;
        }
    }
}
