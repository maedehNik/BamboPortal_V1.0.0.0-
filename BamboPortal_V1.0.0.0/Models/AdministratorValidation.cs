using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security.AntiXss;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;

namespace BamboPortal_V1._0._0._0.Models
{
    public class AdministratorValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var administrator = (Administrator)validationContext.ObjectInstance;
            if (string.IsNullOrEmpty(administrator.Username))
                administrator.Username = AntiXssEncoder.HtmlEncode(administrator.Username, false);
            if (string.IsNullOrEmpty(administrator.Password))
                administrator.Password = AntiXssEncoder.HtmlEncode(administrator.Password, false);
            if (string.IsNullOrEmpty(administrator.urlRedirection))
                administrator.urlRedirection = AntiXssEncoder.UrlEncode(administrator.urlRedirection);
            if (string.IsNullOrEmpty(administrator.id_Admin))
                administrator.id_Admin = AntiXssEncoder.HtmlEncode(administrator.id_Admin, false);
            if (string.IsNullOrEmpty(administrator.ad_typeID))
                administrator.ad_typeID = AntiXssEncoder.HtmlEncode(administrator.ad_typeID, false);
            if (string.IsNullOrEmpty(administrator.ad_firstname))
                administrator.ad_firstname = AntiXssEncoder.HtmlEncode(administrator.ad_firstname, false);
            if (string.IsNullOrEmpty(administrator.ad_lastname))
                administrator.ad_lastname = AntiXssEncoder.HtmlEncode(administrator.ad_lastname, false);
            if (string.IsNullOrEmpty(administrator.ad_avatarprofile))
                administrator.ad_avatarprofile = AntiXssEncoder.UrlEncode(administrator.ad_avatarprofile);
            if (string.IsNullOrEmpty(administrator.ad_email))
                administrator.ad_email = AntiXssEncoder.HtmlEncode(administrator.ad_email, false);
            if (string.IsNullOrEmpty(administrator.ad_phone))
                administrator.ad_phone = AntiXssEncoder.HtmlEncode(administrator.ad_phone, false);
            if (string.IsNullOrEmpty(administrator.ad_mobile))
                administrator.ad_mobile = AntiXssEncoder.HtmlEncode(administrator.ad_mobile, false);
            if (string.IsNullOrEmpty(administrator.ad_has2stepSecurity))
                administrator.ad_has2stepSecurity = AntiXssEncoder.HtmlEncode(administrator.ad_has2stepSecurity, false);
            if (string.IsNullOrEmpty(administrator.ad_isActive))
                administrator.ad_isActive = AntiXssEncoder.HtmlEncode(administrator.ad_isActive, false);
            if (string.IsNullOrEmpty(administrator.ad_isDelete))
                administrator.ad_isDelete = AntiXssEncoder.HtmlEncode(administrator.ad_isDelete, false);
            if (string.IsNullOrEmpty(administrator.ad_lastseen))
                administrator.ad_lastseen = AntiXssEncoder.HtmlEncode(administrator.ad_lastseen, false);
            if (string.IsNullOrEmpty(administrator.ad_lastlogin))
                administrator.ad_lastlogin = AntiXssEncoder.HtmlEncode(administrator.ad_lastlogin, false);
            if (string.IsNullOrEmpty(administrator.ad_loginIP))
                administrator.ad_loginIP = AntiXssEncoder.HtmlEncode(administrator.ad_loginIP, false);
            if (string.IsNullOrEmpty(administrator.ad_regdate))
                administrator.ad_regdate = AntiXssEncoder.HtmlEncode(administrator.ad_regdate, false);
            if (string.IsNullOrEmpty(administrator.ad_personalColorHexa))
                administrator.ad_personalColorHexa = AntiXssEncoder.HtmlEncode(administrator.ad_personalColorHexa, false);
            if (string.IsNullOrEmpty(administrator.AdminModeID))
                administrator.AdminModeID = AntiXssEncoder.HtmlEncode(administrator.AdminModeID, false);
            if (string.IsNullOrEmpty(administrator.ad_NickName))
                administrator.ad_NickName = AntiXssEncoder.HtmlEncode(administrator.ad_NickName, false);

            return ValidationResult.Success;

        }
    }
}