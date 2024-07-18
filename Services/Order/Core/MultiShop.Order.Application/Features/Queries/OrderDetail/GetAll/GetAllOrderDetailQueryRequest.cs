using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.OrderDetail.GetAll
{
    public class GetAllOrderDetailQueryRequest:IRequest<List<GetAllOrderDetailQueryResponse>>
    {
    }
}
