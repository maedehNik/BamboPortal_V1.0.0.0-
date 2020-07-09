using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class AddSubCateGoryValuesOfKeysSubmit
    {
        [MyMaxLengthAttribute(3)]
        [Required(ErrorMessage = "میبایستی که حتما یک سردسته اصلی را انتخاب نمایید!")]
        public string ProductTypeId { get; set; }
        [MyMaxLengthAttribute(3)]
        [Required(ErrorMessage = "میبایستی که حتما یک گروه اصلی را انتخاب نمایید!")]
        public string ProcuctMainCategoryId { get; set; }
        [MyMaxLengthAttribute(3)]
        [Required(ErrorMessage = "میبایستی که حتما یک گروه محصولات را انتخاب نمایید!")]
        public string ProductSubCategoryId { get; set; }
        [MyMaxLengthAttribute(3)]
        [Required(ErrorMessage = "میبایستی که حتما یک نام ویژگی را انتخاب نمایید!")]
        public string ProductSubCategoryKeyID { get; set; }
        [MyMaxLengthAttribute(40)]
        [Required(ErrorMessage = "میبایستی که حتما مقدار ویژگی انتخاب شده را وارد نمایید!")]
        public string ProductSubCategoryValueOfKeyName { get; set; }
        public string ProductSubCategoryValueOfKeyIDForEdit { get; set; }
    }
}