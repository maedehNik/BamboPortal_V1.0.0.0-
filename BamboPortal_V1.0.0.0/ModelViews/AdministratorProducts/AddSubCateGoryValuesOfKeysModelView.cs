﻿using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class AddSubCateGoryValuesOfKeysModelView
    {
        public List<Key_ValueModel> ProductTypes { get; set; }
        public AddSubCateGoryValuesOfKeysSubmit KeySubmit { get; set; }
        public List<ProductGroupModel> Tbl { get; set; }
    }
}