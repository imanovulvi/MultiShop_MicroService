using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Adress.Create
{
    public class CreateAdressCommandRequest:IRequest
    {
        public string UserId { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Destrict { get; set; }
        public string ZipCode { get; set; }
    }
}
