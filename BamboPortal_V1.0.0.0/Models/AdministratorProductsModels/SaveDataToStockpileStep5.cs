using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class SaveDataToStockpileStep5
    {
        public string PriceNumeric { get; set; }
        public string QTnumeric { get; set; }
        public string ProductCode { get; set; }
        public string idMPC { get; set; }
        public string MultyproductQT { get; set; }
        public string MultyproductPricePerQT { get; set; }
    }
    public class SaveDataToStockpileStep5SaveData
    {
        public List<SaveDataToStockpileStep5> sender { set; get; }
    }
}