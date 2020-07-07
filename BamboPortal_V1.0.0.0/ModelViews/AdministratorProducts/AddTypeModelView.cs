using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class AddTypeModelView
    {
        public addtype addtypeField { get; set; }
        public List<AddTypeTable> TableAvailableProperty { get; set; }
        public List<AddTypeTable> TableDeletedProperties { get; set; }
    }
}