using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class MiniProductModel
    {
        public string MainCatename { get; set; }
        public string subCatename { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string PicPath { get; set; }
        public string Discription { get; set; }
        public string PriceXQ { get; set; }
        public string OffPrice { get; set; }
        public string date { get; set; }
        public string MoneyQ { get; set; }
        public string PricePerQ { get; set; }
        public int PriceShowType { get; set; }
        public string OffValue { get; set; }
        public int offType { get; set; }
    }
}