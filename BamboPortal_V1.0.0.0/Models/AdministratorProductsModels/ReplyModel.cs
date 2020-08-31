using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class ReplyModel
    {
        public int RepId { get; set; }
        public string Message { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminPic { get; set; }
        public string RepDate { get; set; }

    }
}