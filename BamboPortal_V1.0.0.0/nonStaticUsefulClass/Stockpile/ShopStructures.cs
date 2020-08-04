using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.nonStaticUsefulClass.Stockpile
{
    public class ShopStructures
    {
        public string ShopID { get; set; }
        public string ShopName { get; set; }
        public Int64 ProductRemaining { get; set; }
        public bool Is_Activate { get; set; }
        public bool Is_Deleted { get; set; }
        public bool UsingFromStockpileForSelling { get; set; }
        public ProductForStockpile ProductInShop { get; set; }
    }
}