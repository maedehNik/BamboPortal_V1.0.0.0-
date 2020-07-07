using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
        public string HintAddress { get; set; }
    }
}