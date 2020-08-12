using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorFactor
{
    public class FactorItrmModel
    {
        public int Num { get; set; }
        public int ProductId { get; set; }
        public int FactorChildId { get; set; }
        public string Title { get; set; }
        public string QuantityType { get; set; }
        public string Quantity { get; set; }
        public string MoneyType { get; set; }
        public string OffCode { get; set; }
        public string OffPrice { get; set; }
        public string PriceAfterOff { get; set; }
        public string PricePerquantity { get; set; }
        public string PurePrice { get; set; }
    }
}