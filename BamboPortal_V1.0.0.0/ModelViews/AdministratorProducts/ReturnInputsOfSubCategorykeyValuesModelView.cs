using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class ReturnInputsOfSubCategorykeyValuesModelView
    {
        public string IdOfKey { get; set; }
        public List<Key_ValueModel> AllKeyValues { get; set; }
        public string KeyNames { get; set; }
    }
}