using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOs.DTOs.Order
{
    public class ResultOrderInfoDTO
    {
        public int AdressId { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Destrict { get; set; }
        public string ZipCode { get; set; }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }


      
    }
}
