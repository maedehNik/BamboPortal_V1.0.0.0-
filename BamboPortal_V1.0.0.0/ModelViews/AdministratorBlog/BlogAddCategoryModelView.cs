using BamboPortal_V1._0._0._0.Models.AdministratorBlogModels;
using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorBlog
{
    public class BlogAddCategoryModelView
    {
        
        public AddBlogCatModel AddCat { get; set; }
        public List<BlogCategoryListModel> CatList { get; set; }

    }
}