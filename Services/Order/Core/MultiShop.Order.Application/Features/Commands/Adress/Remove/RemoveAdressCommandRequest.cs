using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Adress.Remove
{
    public class RemoveAdressCommandRequest:IRequest
    {
        public int Id { get; set; }
    }
}
