using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorBlogModels
{
    public class AddBlogGroupModel
    {
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن نام گروه اجباری میباشد!")]
        public string GName { get; set; }
        [MyMaxLengthAttribute(40)]
        [Required(ErrorMessage = "وارد کردن توکن گروه اجباری میباشد!")]
        public string GToken { get; set; }
        [MyMaxLengthAttribute(4)]
        [Required(ErrorMessage = "توکن مورد نیاز میباشد")]
        public string typeID { get; set; }
    }
}