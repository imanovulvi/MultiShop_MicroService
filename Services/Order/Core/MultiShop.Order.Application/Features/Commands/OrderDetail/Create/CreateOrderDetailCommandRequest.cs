using MediatR;
using MultiShop.Order.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.OrderDetail.Create
{
    public class CreateOrderDetailCommandRequest:IRequest
    {
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal AmountPrice { get; set; }
        public int ProductId { get; set; }

        public int OrderingId { get; set; }

    }
}
