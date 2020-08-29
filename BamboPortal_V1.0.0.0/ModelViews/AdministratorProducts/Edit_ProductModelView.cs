using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class Edit_ProductModelView
    {
        public List<Id_ValueModel> Images { get; set; }
        public List<ProductOptions_Model> OptionList{ get; set; }
        public ProductEditSubmiterModel SubmiterModel{ get; set; }
        public ProductOptions_Model OptionSubmiter { get; set; }

    }
}