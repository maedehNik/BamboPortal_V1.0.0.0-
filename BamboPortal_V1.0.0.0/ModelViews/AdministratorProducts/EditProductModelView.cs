using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class EditProductModelView
    {
        public ProductEditSubmiterModel DataSubmiter { get; set; }
        public List<ProductOptionsModel> Options { get; set; }
        public ProductOptionsModel OptionModel { get; set; }
        public List<Id_ValueModel> Pictures { get; set; }
    }
}