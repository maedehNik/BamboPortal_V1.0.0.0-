using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorBlogModels
{
    public class BlogTagListModel
    {
        public int Num { get; set; }
        public int TagId { get; set; }
        public string CatName { get; set; }
        public string TagName { get; set; }
        public int IsDeleted { get; set; }
        public int Disabled { get; set; }
    }
}