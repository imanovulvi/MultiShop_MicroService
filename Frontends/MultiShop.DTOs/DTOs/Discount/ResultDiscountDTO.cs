using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOs.DTOs.Discount
{
    public class ResultDiscountDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
