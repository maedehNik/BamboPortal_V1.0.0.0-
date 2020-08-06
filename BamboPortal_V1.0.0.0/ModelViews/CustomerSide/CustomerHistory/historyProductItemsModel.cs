using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide.CustomerHistory
{
    public class historyProductTableItemsModel
    {
        public string  id_MPC { get; set; }
        public string ProductName { get; set; }
        public string scoknameandvalue { get; set; }
        public string pricebperQ { get; set; }
        public string  TotalPrice { get; set; }
        public string ProductDimensionName { get; set; }
        public string Countof { get; set; }
        public string ImagePath { get; set; }

    }
    public class historyProductCardItemsModel
    {
        public string PeygiriCode { get; set; }
        public string WhenCreated { get; set; }
        public string PayMentTypeName { get; set; }
        public Int64 TotalPrice { get; set; }
        public Int64 TaxPrice { get; set; }
        public Int64 OffPrice { get; set; }
        public Int64 PayPrice { get; set; }
        public string Ispay { get; set; }
        public List<historyProductTableItemsModel> AllItems { get; set; }

    }
    public class historyProductItemsModelView
    {
        public List<historyProductCardItemsModel> History { get; set; }
    }
}