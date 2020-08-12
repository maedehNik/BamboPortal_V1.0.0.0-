using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorBlogModels
{
    public class BlodGroupListModel
    {
        public int Num { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupToken { get; set; }
        public int IsDeleted { get; set; }
        public int Disabled { get; set; }
    }
}