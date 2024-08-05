using MediatR;
using MultiShop.Order.Application.Repository;
using MultiShop.Order.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetByUserId
{
    public class GetByUserIdOrderingQueryHandler : IRequestHandler<GetByUserIdOrderingQueryRequest, List<GetByUserIdOrderingQueryResponse>>
    {
        private readonly IRepository<ET.Ordering> repository;

        public GetByUserIdOrderingQueryHandler(IRepository<ET.Ordering> repository)
        {
            this.repository = repository;
        }

       


        public async Task<List<GetByUserIdOrderingQueryResponse>> Handle(GetByUserIdOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            List<ET.Ordering> orderings = repository.Filter(x => x.UserId == request.UserId).ToList();

            List<GetByUserIdOrderingQueryResponse> responseList = new List<GetByUserIdOrderingQueryResponse>();
            foreach (var item in orderings)
            {
                responseList.Add(
                    new()
                    {
                        Id = item.Id,
                        UserId = item.UserId,
                        TotalPrice = item.TotalPrice,
                        OrderDate = item.OrderDate

                    }
                    );
            }

            return responseList;
        }
    }
}
