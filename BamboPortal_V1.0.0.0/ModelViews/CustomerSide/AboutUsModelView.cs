using BamboPortal_V1._0._0._0.Models.CustomerSide;
using ShoppingCMS_V002.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.CustomerSide
{
    public class AboutUsModelView
    {
        public List<Company_Customers_Model> CustomerMessages { get; set; }
        public List<tbl_BLOG_TeamMembers> TeamMembers { get; set; }
    }
}