using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorStockpile
{
    public class ShowPSID
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductPurePrice { get; set; }
        public string ProductMultyPrice { get; set; }
        public string ProductDescription { get; set; }
        public List<ProductViewDetails_ProductSOCKandSOCKVLList> socKandSockvlList { get; set; }
        public string id_MPC { get; set; }
        public List<Shops> ShopList { get; set; }
        public List<StockpileTransactionHistoryModel> STHList { get; set; }
        public List<string> PicList { get; set; }
        public string MultyPriceStartFromQ { get; set; }
        public List<Key_ValueModel> ShopAvailable4Transaction { get; set; }
    }
}