using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide
{
    public class ProductDetail_ModelView
    {
        public Product_DesignerModel ProductModel { get; set; }//
        public List<MiniProductModel> Sale_Products { get; set; }//
        public List<ProductFinder> PF { get; set; }//
        public string JsonPF { get; set; }//
        public string JsonSale_Products { get; set; }//
    }

    public class ProductFinder
    {
        public string Idmpc { get; set; }
        public string Code { get; set; }
    }
}