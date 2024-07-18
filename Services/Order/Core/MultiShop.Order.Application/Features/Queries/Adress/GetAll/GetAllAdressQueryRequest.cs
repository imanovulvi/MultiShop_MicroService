using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.Adress.GetAll
{
    public class GetAllAdressQueryRequest:IRequest<List<GetAllAdressQueryResponse>>
    {
    }
}
