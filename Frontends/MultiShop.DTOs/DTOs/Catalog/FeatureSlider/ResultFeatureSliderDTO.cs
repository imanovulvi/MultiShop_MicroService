using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOs.DTOs.Catalog.FeatureSlider
{
    public class ResultFeatureSliderDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; } = true;
    }
}
