using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class ProductViewDetailsModelView
    {
        public string ID_Mainpr { get; set; }
        public string id_MPC { get; set; }
        public List<ProductViewDetails_ProductSOCKandSOCKVLList> ProductsJaygashtList { get; set; }
        public string ProductName { get; set; }
        public string ProductStockpileCode { get; set; }
        public string Description { get; set; }
        public string ProductPrice { get; set; }
        public string LastEdit { get; set; }
        public List<ProductViewDetails_PropertyTable> PropertyTable { get; set; }
        public List<ProductViewDetails_PropertyTable> ProductStoreFromStockpile { get; set; }
        public List<ProductViewDetails_EditTimeLine> EditTimeLine { get; set; }
        public List<string> PicAddress { get; set; }
        public List<string> PriceChart { get; set; }
        public List<string> FactorsChart { get; set; }
        public string PriceTypeName { get; set; }
    }
}