﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DTOsLayer.DTOs.CargoOperation
{
    public class CreateCargoOperationDTO
    {
        public string Barcode { get; set; }
        public DateTime CargoDate { get; set; }
        public string Description { get; set; }
    }
}
