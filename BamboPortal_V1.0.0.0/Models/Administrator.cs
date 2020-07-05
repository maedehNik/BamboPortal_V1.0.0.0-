using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using BamboPortal_V1._0._0._0.StaticClass;

namespace BamboPortal_V1._0._0._0.Models
{
    public class Administrator
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری اجباری میباشد!")]
        [MyMaxLengthAttribute(25)]
        public string   Username { get; set; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور اجباری میباشد!")]
        [MyMaxLengthAttribute(25)]
        public string  Password { get; set; }
        [MyMaxLength(50)]
        public string  urlRedirection { get; set; }
        public string id_Admin { get; set; }
        public string ad_typeID { get; set; }


        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن نام اجباری میباشد!")]
        public string ad_firstname { get; set; }
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن نام خانوادگی اجباری میباشد!")]
        public string ad_lastname { get; set; }

        public string ad_avatarprofile { get; set; }

        [Required(ErrorMessage = "وارد کردن آدرس ایمیل اجباری میباشد!")]
        public string ad_email { get; set; }
        [MyMaxLengthAttribute(12)]
        [Required(ErrorMessage = "وارد کردن شماره تلفن ثابت اجباری میباشد!")]
        public string ad_phone { get; set; }
        [MyMaxLengthAttribute(12)]
        [Required(ErrorMessage = "وارد کردن شماره تلفن همراه اجباری میباشد!")]
        public string ad_mobile { get; set; }
        public string ad_has2stepSecurity { get; set; }
        public string ad_isActive { get; set; }
        public string ad_isDelete { get; set; }
        public string ad_lastseen { get; set; }
        public string ad_lastlogin { get; set; }
        public string ad_loginIP { get; set; }
        public string ad_regdate { get; set; }
        public string ad_personalColorHexa { get; set; }
        public string AdminModeID { get; set; }
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن نام قابل نمایش اجباری میباشد!")]
        public string ad_NickName { get; set; }

        public string ad_avatarPicIDfromUploader { get; set; }

    }

}