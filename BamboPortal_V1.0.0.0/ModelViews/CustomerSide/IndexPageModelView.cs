using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide
{
    public class IndexPageModelView
    {
        public List<MiniProductModel> SelectedProducts { get; set; }
        public List<MiniProductModel> Sale_Products { get; set; }
        public List<MiniProductModel> NewProducts { get; set; }
        public List<MiniProductModel> ProductsG3 { get; set; }
        public List<StoreModel> Stores { get; set; }

    }
}