using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.Ordering.GetByUserId
{
    public class GetByUserIdOrderingQueryRequest:IRequest<List<GetByUserIdOrderingQueryResponse>>
    {
        public string UserId { get; set; }
    }
}
