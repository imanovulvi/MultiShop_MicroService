using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DTOsLayer.DTOs.CargoDetail
{
    public class UpdateCargoDetailDTO
    {
        public int Id { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public int Barcode { get; set; }
        public int CompanyId { get; set; }
    }
}
