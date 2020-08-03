using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorStockpile
{
    public class StockpileTransactionHistoryModel
    {
        public string ShopID { get; set; }
        public string Dimension { get; set; }
        public string HajmVarede { get; set; }
        public string HajmSadere { get; set; }
        public string TotalPriceOfVarede { get; set; }
        public string TotalPriceOfsadere { get; set; }
        public string ShopName { get; set; }
        public string TransActionDate { get; set; }
        public string MiyanginGheymateVarede { get; set; }
        public string MiyanginGheymateSadere { get; set; }
        public string Mojoodi { get; set; }
        public string BootstrapColor { get; set; }
    }
}