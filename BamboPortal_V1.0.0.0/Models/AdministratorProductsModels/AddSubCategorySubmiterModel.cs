using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class AddSubCategorySubmiterModel
    {
        [MyMaxLengthAttribute(3)]
        [Required(ErrorMessage = "میبایستی که حتما یک سردسته اصلی را انتخاب نمایید!")]
        public string typeID { get; set; }
        [MyMaxLengthAttribute(3)]
        [Required(ErrorMessage = "میبایستی که حتما یک گروه اصلی را انتخاب نمایید!")]
        public string MainCategoryID { get; set; }
        public string IdSubCategoryForEdit { get; set; }
        [MyMaxLengthAttribute(40)]
        [Required(ErrorMessage = "میبایستی که حتما نام گروه را مشخص نمایید نمایید!")]
        public string SubCategoryName { get; set; }
    }
}