using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorBlogModels
{
    public class BlogCategoryListModel
    {
        public int Num { get; set; }
        public int CatId { get; set; }
        public string CatName { get; set; }
        public int IsDeleted { get; set; }
        public int Disabled { get; set; }
    }
}