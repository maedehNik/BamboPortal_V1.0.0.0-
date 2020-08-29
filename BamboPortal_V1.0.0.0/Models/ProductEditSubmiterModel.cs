using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models
{
    public class ProductEditSubmiterModel
    {
        public int ProId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SEO_keyword { get; set; }
        public string SEO_Description { get; set; }
        public int Weight { get; set; }
        public int IsImportant { get; set; }
        public string Pics { get; set; }
    }
}