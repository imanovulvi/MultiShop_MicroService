using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOs.DTOs.Discount
{
    public class ResultTotalDTO
    {
        public decimal Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountTotal { get; set; }
    }
}
