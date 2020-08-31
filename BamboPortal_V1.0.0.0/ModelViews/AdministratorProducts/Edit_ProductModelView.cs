using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class Edit_ProductModelView
    {
        public string idMainProduct { get; set; }
        public string idMPC { get; set; }
        public List<ProductViewDetails_ProductSOCKandSOCKVL> ProductsJaygashtList { get; set; }
        public string ProductName { get; set; }
        public List<ProductImagesObj> Allimgs { get; set; }
        public string GheymateVahed { get; set; }
        public string TedadeVahed { get; set; }
        public string GheymatevahedOmde { get; set; }
        public string TedadeVahedOmde { get; set; }
        public List<Key_ValueModel> MainTags { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public List<productOptionsTbl> AllOptions { get; set; }
        public string AllImagesByID { get; set; }
        public string Description { get; set; }
        public string MainTagSelected { get; set; }
    }

    public class productOptionsTbl
    {
        public string idOption { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}