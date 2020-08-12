using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorBlogModels
{
    public class AddTagModel
    {
        [MyMaxLengthAttribute(4)]
        [Required(ErrorMessage = "وارد کردن شناسه ی دسته بندی اجباری است.")]
        public string CatId { get; set; }
        [MyMaxLengthAttribute(50)]
        [Required(ErrorMessage = "وارد کردن نام برچسب اجباری است.")]
        public string TagName { get; set; }
        [MyMaxLengthAttribute(4)]
        [Required(ErrorMessage = "توکن مورد نیاز میباشد")]
        public string typeID { get; set; }

    }
}