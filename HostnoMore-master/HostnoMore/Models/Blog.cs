using System;
using System.Collections.Generic;
using System.Text;

namespace HostnoMore.Models
{
    public class Blog
    {
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public double Price { get; set; }
        public double PriceSmall { get; set; }
        public double PriceMedium { get; set; }
        public double PriceLarge { get; set; }
        public string imageName { get; set; }
    }
}
