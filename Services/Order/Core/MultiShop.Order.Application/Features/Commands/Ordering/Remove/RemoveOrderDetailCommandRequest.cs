using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Ordering.Remove
{
    public class RemoveOrderingCommandRequest:IRequest
    {
        public int Id { get; set; }
    }
}
