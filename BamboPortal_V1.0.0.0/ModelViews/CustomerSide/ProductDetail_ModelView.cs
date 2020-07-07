using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide
{
    public class ProductDetail_ModelView
    {
        public Product_DesignerModel ProductModel { get; set; }
        public List<MiniProductModel> Sale_Products { get; set; }
    }
}