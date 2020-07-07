using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class TreeModel
    {
        public int Id { get; set; }
        public string NameSub { get; set; }
        public bool IsActive { get; set; }
        public List<TreeModel> Subs { get; set; }
    }
}