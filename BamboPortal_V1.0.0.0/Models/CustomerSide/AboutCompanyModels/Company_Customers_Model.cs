using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class Company_Customers_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Message { get; set; }
        public int stars { get; set; }
        public string ImagePath { get; set; }
    }
}