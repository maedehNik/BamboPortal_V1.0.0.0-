using BamboPortal_V1._0._0._0.Models.AdministratorBlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorBlog
{
    public class BlogAddGroupModelView
    {
        public AddBlogGroupModel AddModel { get; set; }
        public List<BlodGroupListModel> GroupList { get; set; }
    }
}