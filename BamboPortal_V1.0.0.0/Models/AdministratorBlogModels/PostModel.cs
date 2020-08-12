using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorBlogModels
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Text_min { get; set; }
        public string Text { get; set; }
        public string CatId { get; set; }
        public string GroupId { get; set; }
        public string Tags { get; set; }
        public int Weight { get; set; }
        public bool IsImportant { get; set; }
        public string Pics { get; set; }
        public string typeID { get; set; }
    }
}