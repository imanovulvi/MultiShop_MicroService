using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.EntitysLayer.Entitys
{
    public class CargoDetail
    {
        public int Id { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public int Barcode { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
