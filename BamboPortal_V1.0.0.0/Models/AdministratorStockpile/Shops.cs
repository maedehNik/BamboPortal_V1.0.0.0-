using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorStockpile
{
    public class Shops
    {
        public string ShopName { get; set; }
        public bool CalCulatingFromShop { get; set; }
        public bool ISActivate { get; set; }
        public string ProductAvailableCount { get; set; }
        public string  BootstrapColor { get; set; }
    }
}