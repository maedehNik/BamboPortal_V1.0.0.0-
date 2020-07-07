using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide
{
    public class ShoppingCartModelView
    {
        public FactorPopUpModel FactorModel { get; set; }
        public List<Id_ValueModel> Ostan { get; set; }
        public List<AddressModel> Adresses { get; set; }
        public CustomerDetail Customer { get; set; }
    }
}