using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorBlogModels
{
    public class PostTableModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string PicPath { get; set; }
        public string SeenNumber { get; set; }
        public string LatEditDate { get; set; }
        public string Text_Min { get; set; }
        public int Deleted { get; set; }
        public int Disabled { get; set; }
    }
}