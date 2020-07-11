using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class AddproductGetAllFinallyPriceDataAboutProductsModelView
    {
        public List<Key_ValueModel> PriceType { get; set; }
        public List<Key_ValueModel> QuantityTypes { get; set; }
        public List<Key_ValueModel> OffTypes { get; set; }
        public List<Key_ValueModel> PriceShow { get; set; }
        public List<Key_ValueModel> Tags { get; set; }
        public List<Key_ValueModel> MainTags { get; set; }
    }
}