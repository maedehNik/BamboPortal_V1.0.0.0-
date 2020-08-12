using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorBlogModels
{
    public class AddBlogCatModel
    {
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن نام دسته بندی اجباری میباشد!")]
        public string AddCat { get; set; }

        [MyMaxLengthAttribute(4)]
        [Required(ErrorMessage = "توکن مورد نیاز میباشد")]
        public string typeID { get; set; }
    }
}