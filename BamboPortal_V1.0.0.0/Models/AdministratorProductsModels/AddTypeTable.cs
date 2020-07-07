using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class AddTypeTable
    {
        public int id { get; set; }
        public string RowColumnNumber { get; set; }
        public string Typename { get; set; }
        public int IsActivate { get; set; }
        public int IsDeleted { get; set; }

    }
}