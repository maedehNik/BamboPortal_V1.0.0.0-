using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BamboPortal_V1._0._0._0.StaticClass;

namespace BamboPortal_V1._0._0._0.Models
{
    public class LoginAuthForm
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری اجباری میباشد!")]
        [MyMaxLength(25)]
        public string Username { get; set; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور اجباری میباشد!")]
        [MyMaxLength(25)]
        public string Password { get; set; }
        [MyMaxLength(50)]
        public string urlRedirection { get; set; }
    }
}