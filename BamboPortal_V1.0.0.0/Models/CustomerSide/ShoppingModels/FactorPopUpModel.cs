using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class FactorPopUpModel
    {
       
        public int Id { get; set; }
        public string totality { get; set; }
        public string Deposit { get; set; }
        public List<ShoppingCart_item> items { get; set; }
        public string MoneyQuantity { get; set; }
        public int itemNumbers { get; set; }
        public int Done { get; set; }
        public int deleted { get; set; }
        public string PaymentSerial { get; set; }
        public string PaymentToken { get; set; }
        public AddressModel Address { get; set; }
        public int CustomerId { get; set; }
        public string Date { get; set; }
        public string Off_Code { get; set; }
    }
}