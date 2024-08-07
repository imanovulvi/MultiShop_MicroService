using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOs.DTOs.Catalog.Statistic
{
    public class ResultStatisticDTO
    {
        public long BrandCount { get; set; }
        public long CategoryCount { get; set; }
        public long ProductCount { get; set; }
        public string MaxPriceProductName { get; set; }
        public string MinPriceProductName { get; set; }
    }
}
