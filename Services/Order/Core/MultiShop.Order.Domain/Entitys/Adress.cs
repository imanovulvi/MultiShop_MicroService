﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Domain.Entitys
{
    public class Adress
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Destrict { get; set; }
        public string ZipCode { get; set; }

    }
}
