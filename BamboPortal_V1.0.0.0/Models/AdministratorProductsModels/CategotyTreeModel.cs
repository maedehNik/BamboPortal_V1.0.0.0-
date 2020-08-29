using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class CategotyTreeModel
    {
        public int Id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public List<CategotyTreeModel> children { get; set; }

    }
}