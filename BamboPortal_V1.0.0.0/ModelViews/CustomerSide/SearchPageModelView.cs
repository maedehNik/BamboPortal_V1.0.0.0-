using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide
{
    public class SearchPageModelView
    {
        public int Pages { get; set; }
        public int thisPage { get; set; }
        public List<TreeModel> Cateqories { get; set; }
        public List<MiniProductModel> Products { get; set; }
        public string Cat { get; set; }
        public int CatId { get; set; }
        public string Search { get; set; }
    }
}