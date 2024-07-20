using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.EntitysLayer.Entitys
{
    public class CargoOperation
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public DateTime CargoDate { get; set; }
        public string Description { get; set; }
    }
}
