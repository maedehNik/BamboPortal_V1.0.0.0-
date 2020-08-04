using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.AdministratorStockpile;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorStockpile
{
    public class ProductInStockpileModelView
    {
        public ShowPSID ShowPSIDs { get; set; }

        public InOutStructure InOutStructures { get; set; }

    }
}