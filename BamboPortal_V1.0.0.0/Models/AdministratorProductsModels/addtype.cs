using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class addtype
    {
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن نام سردسته اجباری میباشد!")]
        public string ProductType { get; set; }
        [MyMaxLengthAttribute(4)]
        [Required(ErrorMessage = "توکن مورد نیاز میباشد")]
        public string typeID { get; set; }
    }
}