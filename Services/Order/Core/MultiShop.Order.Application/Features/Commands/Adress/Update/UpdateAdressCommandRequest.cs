using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Adress.Update
{
    public class UpdateAdressCommandRequest:IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Destrict { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
