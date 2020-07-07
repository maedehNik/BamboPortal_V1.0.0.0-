using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class MPCModel
    {
        public int Id { get; set; }
        public string PricePerQ { get; set; }
        public string PriceXQ { get; set; }
        public string PriceOff { get; set; }
        public int OffType { get; set; }
        public string OffValue { get; set; }
        public string Properties { get; set; }
        public string JsonProperty { get; set; }
    }
}