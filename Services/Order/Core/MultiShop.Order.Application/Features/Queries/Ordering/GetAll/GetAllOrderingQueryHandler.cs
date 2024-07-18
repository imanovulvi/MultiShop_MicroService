using MediatR;
using MultiShop.Order.Application.Features.Queries.OrderDetail.GetAll;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetAll
{
    public class GetAllOrderingQueryHandler:IRequestHandler<GetAllOrderingQueryRequest,List<GetAllOrderingQueryResponse>>
    {
        private readonly IRepository<ET.Ordering> repository;

        public GetAllOrderingQueryHandler(IRepository<ET.Ordering> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetAllOrderingQueryResponse>> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await repository.GetAllAsync();

            List<GetAllOrderingQueryResponse> response = new();
            foreach (var item in list)
            {
                response.Add(new GetAllOrderingQueryResponse()
                {
                    Id = item.Id,
                    TotalPrice = item.TotalPrice,
                    OrderDate = item.OrderDate,
                    UserId = item.UserId

                });
            }

            return response;
        }
    }
}
