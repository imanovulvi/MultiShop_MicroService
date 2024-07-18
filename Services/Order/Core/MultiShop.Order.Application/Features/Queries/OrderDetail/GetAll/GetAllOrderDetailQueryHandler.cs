using MediatR;
using MultiShop.Order.Application.Features.Queries.Adress.GetAll;
using MultiShop.Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET = MultiShop.Order.Domain.Entitys;

namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetAll
{
    public class GetAllOrderDetailQueryHandler:IRequestHandler<GetAllOrderDetailQueryRequest, List<GetAllOrderDetailQueryResponse>>
    {
        private readonly IRepository<ET.OrderDetail> repository;

        public GetAllOrderDetailQueryHandler(IRepository<ET.OrderDetail> repository)
        {
            this.repository = repository;
        }

        
        public async Task<List<GetAllOrderDetailQueryResponse>> Handle(GetAllOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var list = await repository.GetAllAsync();

            List<GetAllOrderDetailQueryResponse> response = new();
            foreach (var item in list)
            {
                response.Add(new GetAllOrderDetailQueryResponse()
                {
                    Id = item.Id,
                    AmountPrice = item.AmountPrice,
                    OrderingId = item.OrderingId,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    TotalPrice = item.TotalPrice

                });
            }

            return response;
        }
    }
}
