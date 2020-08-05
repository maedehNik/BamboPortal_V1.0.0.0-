using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide
{
    public class ShoppingBasket
    {
        public List<ShoppingBasketItems> Items { get; set; }
        public bool islogin { get; set; }
    }

    public class ShoppingBasketItems
    {
        public int RowNumber { get; set; }
        public string idmpc { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int CountOf { get; set; }
        public Int64 Totals { get; set; }
        public Int64 PriceXQ { get; set; }
  
    }
}