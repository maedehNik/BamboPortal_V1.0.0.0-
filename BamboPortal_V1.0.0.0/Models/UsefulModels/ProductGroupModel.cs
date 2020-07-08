using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.UsefulModels
{
    public class ProductGroupModel
    {
        public int Num { get; set; }
        public int Id { get; set; }
        public int IsDeleted { get; set; }
        public int IsDisables { get; set; }
        public string Type { get; set; }
        public string Main { get; set; }
        public string Sub { get; set; }
        public string SubK { get; set; }
        public string SubVal { get; set; }
        public string IDtype { get; set; }
    }
}