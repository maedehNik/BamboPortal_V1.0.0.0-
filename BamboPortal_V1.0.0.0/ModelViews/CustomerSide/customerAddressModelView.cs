using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide
{
    public class customerAddressModelView
    {
        public List<Id_ValueModel> City { get; set; }
        public List<AddressModel> Addresses { get; set; }
    }
}