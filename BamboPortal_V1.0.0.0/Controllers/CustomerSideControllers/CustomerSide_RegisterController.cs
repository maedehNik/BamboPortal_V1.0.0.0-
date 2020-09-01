using BamboPortal_V1._0._0._0.BamboPortalSecurity.EncDec;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    [RoutePrefix("گالری-پارچه-ولوت")]
    public class CustomerSide_RegisterController : CustomerSide_CustomerRuleController
    {
        [Route("ورود-ثبت-نام-کاربر")]
        public ActionResult loginandregister()
        {
            return View();
        }

        public ActionResult mobileverify()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginAuth(string mobile, string password)
        {
            var ModelSender = new ErrorReporterModel();
            if (string.IsNullOrEmpty(mobile))
            {
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX1075463",
                    Errormessage = $"لطفا شماره موبایل خودرا وارد نمایید",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX1075463",
                    Errormessage = $"لطفا کلمه عبور را وارد نمایید",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
            EncDec dn = new EncDec();
            password = dn.HMACMD5Generator(password);
            PDBC db = new PDBC();
            List<ExcParameters> pars = new List<ExcParameters>();
            ExcParameters par = new ExcParameters()
            {
                _KEY = "@Mobile",
                _VALUE = mobile
            };
            pars.Add(par);
            par = new ExcParameters()
            {
                _KEY = "@PASS",
                _VALUE = password
            };
            pars.Add(par);
            db.Connect();
            DataTable dt = db.Select("SELECT [id_Customer] ,[C_Mobile] ,[C_FirstName] ,[C_LastNAme] FROM [tbl_Customer_Main] WHERE [C_Mobile] LIKE @Mobile AND [C_Password] LIKE @PASS AND [C_ISActivate] = 1" , pars);
            db.DC();
            if (dt.Rows.Count == 1)
            {
                tbl_Customer_Main tcm = new tbl_Customer_Main()
                {
                    id_Customer = dt.Rows[0]["id_Customer"].ToString(),
                    C_FirstName = dt.Rows[0]["C_FirstName"].ToString(),
                    C_LastNAme = dt.Rows[0]["C_LastNAme"].ToString(),
                    C_Mobile = dt.Rows[0]["C_Mobile"].ToString()
                };
                try
                {
                    var userCookieIDV = new HttpCookie(ProjectProperies.AuthCustomerCode());
                    userCookieIDV.Value = CoockieController.SetCustomerAUTHCookie(tcm); 
                    userCookieIDV.Expires = DateTime.Now.AddDays(2);
                    Response.SetCookie(userCookieIDV);
                }
                catch (Exception coockieEXception)
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.coockieAuth)
                    {
                        EXOBJ = coockieEXception
                    };
                    ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX1075463",
                        Errormessage = $"عدم توانایی در ایجاد نشست فعال برای شما با پشتیبانی تماس حاصل فرمایید کد ارور شما {rep.CodeGenerated}",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "SX106",
                    Errormessage = $"با موفقیت وارد شدید!",
                    Errortype = "Success"
                };
                return Json(ModelSender);
            }
            else
            {
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"کاربری با این مشخصات یافت نشد!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }
    }
}