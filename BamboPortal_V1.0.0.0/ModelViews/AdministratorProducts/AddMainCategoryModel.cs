using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class AddMainCategoryModel
    {
        public List<Key_ValueModel> dastebandi_asli { get; set; }
        public List<ProductGroupModel> Table { set; get; }
        public AddMainCategorySubmiterForm FormSubmiting { get; set; }
    }
}