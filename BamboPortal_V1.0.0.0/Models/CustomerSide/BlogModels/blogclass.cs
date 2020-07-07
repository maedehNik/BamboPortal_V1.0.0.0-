using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class blogclass
    {
        public IEnumerable<tbl_BLOG> BLOG { set; get; }
        public tbl_BLOG BLOGPOST { set; get; }
        public List<tbl_BLOG> BLOG_Categories { set; get; }
        public List<tbl_BLOG> BLOG_Tags { set; get; }
        public List<tbl_BLOG> TabS1 { set; get; }
        public List<tbl_BLOG> TabS2 { set; get; }
        public page pages { set; get; }
    }
}