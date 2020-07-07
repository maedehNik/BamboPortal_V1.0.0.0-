
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class Product_DesignerModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public List<Id_ValueModel> Tags { get; set; }
        public string Type { get; set; }
        public string MainCat { get; set; }
        public string SubCat { get; set; }
        public List<string> Pictures { get; set; }
        public List<TreeModel> MPC_Options { get; set; }
        public List<OptionModel> Options { get; set; }
        public List<CommentsModel> Comments { get; set; }
        public string Price { get; set; }
        public string PriceOff { get; set; }
        public int SubCatId { get; set; }
        public string SEO_Keyword { get; set; }
        public string SEO_Discription { get; set; }
        public string PriceQuantity { get; set; }
        public string Quantity { get; set; }
        public List<MPCModel> MPCs { get; set; }


    }
}