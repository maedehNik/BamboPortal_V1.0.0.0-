using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class ReturnInputsOfSubCategorykeyValues
    {
        public string SubCategoryID { get; set; }
        public List<Key_ValueModel> SubCategoryAllKeyValues{ get; set; }
        public string NameOfSubCategoryKey { get; set; }

    }
}