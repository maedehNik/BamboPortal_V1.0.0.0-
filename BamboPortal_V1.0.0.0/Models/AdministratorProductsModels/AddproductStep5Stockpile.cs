using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class AddproductStep5Stockpile
    {
        public string id_MPC { get; set; }
        public List<ProductViewDetails_ProductSOCKandSOCKVL> ProductsJaygashtList { get; set; }
        public string ProductName { get; set; }
        public string productQT { get; set; }
        public string productPricePerQT { get; set; }
        public string MoneyType { get; set; }
        public string QTDemansion { get; set; }
    }
}