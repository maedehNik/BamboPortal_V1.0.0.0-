using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BamboPortal_V1._0._0._0.BamboPortalSecurity.EncDec;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdminLoginAuthController : Controller
    {
        // GET: AdminLoginAuth
        [HttpGet]
        public ActionResult Index()
        {

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            ViewBag.pageTitle = TitleFounder.GetAdminPanelTitle(controllerName, actionName);
            if (TempData["urlRedirection"] != null)
            {
                ViewBag.urlRedirected = TempData["urlRedirection"] as string;

            }
            else
            {

                ViewBag.urlRedirected = "";
            }
            return View();
        }
        [HttpPost]
        [AdministratorValidation]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAuth(LoginAuthForm adObj)
        {
            if (ModelState.IsValid)
            {
                EncDec dn = new EncDec();
                adObj.Password = dn.HMACMD5Generator(adObj.Password);
                PDBC db = new PDBC();
                List<ExcParameters> parasms = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters()
                {
                    _KEY = "@username",
                    _VALUE = adObj.Username
                };
                parasms.Add(parameters);
                parameters = new ExcParameters()
                {
                    _KEY = "@password",
                    _VALUE = adObj.Password
                };
                parasms.Add(parameters);
                db.Connect();
                using (DataTable dt = db.Select("SELECT * FROM [tbl_ADMIN_main] WHERE ad_username LIKE @username AND ad_password LIKE @password", parasms))
                {
                    db.DC();
                    int dtrowcount = dt.Rows.Count;
                    if (dtrowcount > 0)
                    {
                        if (dt.Rows[0]["ad_isActive"].ToString() == "1")
                        {
                            Administrator AdminSession = new Administrator()
                            {
                                id_Admin = dt.Rows[0]["id_Admin"].ToString()
                                ,
                                ad_typeID = dt.Rows[0]["ad_typeID"].ToString()
                                ,
                                ad_firstname = dt.Rows[0]["ad_firstname"].ToString()
                                ,
                                ad_lastname = dt.Rows[0]["ad_lastname"].ToString()
                                ,
                                ad_avatarprofile = dt.Rows[0]["ad_avatarprofile"].ToString()
                                ,
                                ad_email = dt.Rows[0]["ad_email"].ToString()
                                ,
                                ad_phone = dt.Rows[0]["ad_phone"].ToString()
                                ,
                                ad_mobile = dt.Rows[0]["ad_mobile"].ToString()
                                ,
                                ad_has2stepSecurity = dt.Rows[0]["ad_has2stepSecurity"].ToString()
                                ,
                                ad_isActive = dt.Rows[0]["ad_isActive"].ToString()
                                ,
                                ad_isDelete = dt.Rows[0]["ad_isDelete"].ToString()
                                ,
                                ad_lastseen = dt.Rows[0]["ad_lastseen"].ToString()
                                ,
                                ad_lastlogin = dt.Rows[0]["ad_lastlogin"].ToString()
                                ,
                                ad_loginIP = dt.Rows[0]["ad_loginIP"].ToString()
                                ,
                                ad_regdate = dt.Rows[0]["ad_regdate"].ToString()
                                ,
                                ad_personalColorHexa = dt.Rows[0]["ad_personalColorHexa"].ToString()
                                ,
                                AdminModeID = dt.Rows[0]["AdminModeID"].ToString()
                                ,
                                ad_NickName = dt.Rows[0]["ad_NickName"].ToString(),
                                Username = adObj.Username
                            };
                            try
                            {
                                Session["AdministratorRegistery"] = AdminSession;
                                try
                                {
                                    var userCookieIDV = new HttpCookie(ProjectProperies.AuthCoockieCode());
                                    userCookieIDV.Value = CoockieController.SetCoockie(AdminSession); ;
                                    userCookieIDV.Expires = DateTime.Now.AddYears(5);
                                    Response.SetCookie(userCookieIDV);
                                }
                                catch (Exception coockieEXception)
                                {
                                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.coockieAuth)
                                    {
                                        EXOBJ = coockieEXception
                                    };
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX103",
                                        Errormessage = $"عدم توانایی در ایجاد نشست فعال برای شما با پشتیبانی تماس حاصل فرمایید کد ارور شما {rep.CodeGenerated}",
                                        Errortype = "Error"
                                    };
                                    ViewBag.EXLogin = ModelSender;
                                    return View("Index");
                                }
                                if (string.IsNullOrEmpty(adObj.urlRedirection))
                                {
                                    return RedirectToAction("Index");
                                }
                                else
                                {
                                    string[] GotToPage = adObj.urlRedirection.Split('-');
                                    string actionname = "";
                                    string controllername = "";
                                    for (int i = 0; i < 2; i++)
                                    {
                                        if (GotToPage[i].Contains("A_"))
                                        {
                                            actionname = GotToPage[i].Replace("A_", "");
                                        }
                                        else
                                        {
                                            controllername = GotToPage[i];
                                        }
                                    }
                                    return RedirectToAction(actionname, controllername);
                                }
                            }
                            catch (Exception SessionException)
                            {
                                PPBugReporter rep = new PPBugReporter(BugTypeFrom.sessionAuth)
                                {
                                    EXOBJ = SessionException
                                };
                                var ModelSender = new ErrorReporterModel
                                {
                                    ErrorID = "EX103",
                                    Errormessage = $"عدم توانایی در ایجاد نشست فعال برای شما با پشتیبانی تماس حاصل فرمایید کد ارور شما {rep.CodeGenerated}",
                                    Errortype = "Error"
                                };
                                ViewBag.EXLogin = ModelSender;
                                return View("Index");
                            }
                        }
                        else
                        {
                            var ModelSender = new ErrorReporterModel
                            {
                                ErrorID = "EX101",
                                Errormessage = "کاربر پیدا شده در وضعیت غیر فعال میباشد و اجازه دسترسی به پنل را نخواهد داشت",
                                Errortype = "Error"
                            };
                            ViewBag.EXLogin = ModelSender;
                            return View("Index");
                        }
                    }
                    else
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX102",
                            Errormessage = "کاربری با این مشخصات یافت نشد!",
                            Errortype = "Error"
                        };
                        ViewBag.EXLogin = ModelSender;
                        return View("Index");
                    }

                }
                db.DC();
                return View("Index");
            }
            else
            {
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX100",
                    Errormessage = "درخواست ارسال شده مطابق با ساختار امنیتی نمیباشد",
                    Errortype = "Error"
                };
                ViewBag.EXLogin = ModelSender;
                return View("Index");
            }
        }

        public ActionResult LogOut()
        {

            Session["AdministratorRegistery"] = null;
            FormsAuthentication.SignOut();
            Session.Abandon();
            if (Request.Cookies[ProjectProperies.AuthCoockieCode()] != null)
            {
                var c = new HttpCookie(ProjectProperies.AuthCoockieCode());
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("index", "AdminLoginAuth");
        }

        public ActionResult Logs()
        {
            return View();
        }
    }
}