using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorGeneralModels
{
    public class changeAuthInformation
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری اجباری میباشد!")]
        [MyMaxLength(25)]
        public string Username { get; set; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور قبلی اجباری میباشد!")]
        [MyMaxLength(25)]
        public string OLDpassword { get; set; }
        [MyMaxLength(25)]
        public string Newpassword1 { get; set; }
        [MyMaxLength(25)]
        public string Newpassword2 { get; set; }

    }
}