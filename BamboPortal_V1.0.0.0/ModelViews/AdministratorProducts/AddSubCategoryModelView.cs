using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class AddSubCategoryModelView
    {
        public List<ProductGroupModel> Tbl { get; set; }
        public AddSubCategorySubmiterModel SubmiterModel { get; set; }
        public List<Key_ValueModel> IdTypes { get; set; }


    }
}