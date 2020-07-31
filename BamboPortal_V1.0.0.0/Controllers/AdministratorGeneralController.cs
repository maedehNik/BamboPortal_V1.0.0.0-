using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BamboPortal_V1._0._0._0.BamboPortalSecurity.EncDec;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorGeneralModels;
using BamboPortal_V1._0._0._0.Models.MasterObjetsModel;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using BamboPortal_V1._0._0._0.StaticClass.UploaderStaticsCalculators;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorGeneralController : AdminRulesController
    {
        // GET: AdministratorGeneral
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdministratorValidation]
        public ActionResult Index(ChangeProfileModel adObj1)
        {
            Administrator adObj = adObj1.administrator;
            if (ModelState.IsValid)
            {
                string adminID = "";
                try
                {
                    adminID = ((Administrator)Session["AdministratorRegistery"]).id_Admin;
                }
                catch (Exception exception)
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.sessionAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj1)}")
                    {
                        EXOBJ = exception
                    };
                }
                //If Session Doesent work 
                try
                {
                    HttpCookie cookie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCoockieCode());
                    adminID = CoockieController.SayMyName(cookie.Value).id_Admin;
                }
                catch (Exception EX)
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.coockieAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj1)}")
                    {
                        EXOBJ = EX
                    };
                }
                if (string.IsNullOrEmpty(adminID))
                {
                    adminID = "NO-ID";
                }

                PDBC db = new PDBC();
                List<ExcParameters> dbparams = new List<ExcParameters>();
                adObj.ad_avatarprofile = "/AdminDesignResource/app/media/img/users/100_12.jpg";
                ExcParameters param = new ExcParameters()
                {
                    _VALUE = adminID,
                    _KEY = "@id_Admin"
                };
                dbparams.Add(param);
                param = new ExcParameters()
                {
                    _VALUE = adObj.ad_firstname,
                    _KEY = "@ad_firstname"
                };
                dbparams.Add(param);

                param = new ExcParameters()
                {
                    _VALUE = adObj.ad_lastname,
                    _KEY = "@ad_lastname"
                };
                dbparams.Add(param);
                param = new ExcParameters()
                {
                    _VALUE = adObj.ad_avatarprofile,
                    _KEY = "@ad_avatarprofile"
                };
                dbparams.Add(param);
                param = new ExcParameters()
                {
                    _VALUE = adObj.ad_email,
                    _KEY = "@ad_email"
                };
                dbparams.Add(param);
                param = new ExcParameters()
                {
                    _VALUE = adObj.ad_phone,
                    _KEY = "@ad_phone"
                };
                dbparams.Add(param);
                param = new ExcParameters()
                {
                    _VALUE = adObj.ad_mobile,
                    _KEY = "@ad_mobile"
                };
                dbparams.Add(param);
                param = new ExcParameters()
                {
                    _VALUE = adObj.ad_NickName,
                    _KEY = "@ad_NickName"
                };
                dbparams.Add(param);

                db.Connect();
                string result = db.Script(
                      "UPDATE [tbl_ADMIN_main] SET [ad_firstname] = @ad_firstname ,[ad_lastname] = @ad_lastname ,[ad_avatarprofile] = @ad_avatarprofile ,[ad_email] = @ad_email ,[ad_phone] = @ad_phone ,[ad_mobile] = @ad_mobile ,[ad_NickName] = @ad_NickName WHERE id_Admin=@id_Admin",
                      dbparams);
                db.DC();
                if (result == "1")
                {

                    try
                    {
                        var sessionChanger = (Administrator)Session["AdministratorRegistery"];
                        sessionChanger.ad_avatarprofile = adObj.ad_avatarprofile;
                        sessionChanger.ad_NickName = adObj.ad_NickName;
                        sessionChanger.ad_firstname = adObj.ad_firstname;
                        sessionChanger.ad_lastname = adObj.ad_lastname;
                        sessionChanger.ad_email = adObj.ad_email;
                        sessionChanger.ad_phone = adObj.ad_phone;
                        sessionChanger.ad_mobile = adObj.ad_mobile;
                        Session["AdministratorRegistery"] = sessionChanger;
                    }
                    catch (Exception EX)
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.sessionAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj LINE 126)}")
                        {
                            EXOBJ = EX
                        };
                    }
                    try
                    {
                        HttpCookie cookie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCoockieCode());
                        var sessionChanger = CoockieController.SayMyName(cookie.Value);
                        sessionChanger.ad_avatarprofile = adObj.ad_avatarprofile;
                        sessionChanger.ad_NickName = adObj.ad_NickName;
                        sessionChanger.ad_firstname = adObj.ad_firstname;
                        sessionChanger.ad_lastname = adObj.ad_lastname;
                        sessionChanger.ad_email = adObj.ad_email;
                        sessionChanger.ad_phone = adObj.ad_phone;
                        sessionChanger.ad_mobile = adObj.ad_mobile;
                        var userCookieIDV = new HttpCookie(ProjectProperies.AuthCoockieCode());
                        userCookieIDV.Value = CoockieController.SetCoockie(sessionChanger); ;
                        userCookieIDV.Expires = DateTime.Now.AddYears(5);
                        Response.SetCookie(userCookieIDV);
                    }
                    catch (Exception EX)
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.coockieAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj LINE 126)}")
                        {
                            EXOBJ = EX
                        };
                    }

                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX101",
                        Errormessage = "اطلاعات کاربری با موفقیت ویرایش شد!",
                        Errortype = "Success"
                    };

                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX103",
                        Errormessage = $"عدم توانایی در ویرایش اطلاعات با پشتیبانی تماس حاصل فرمایید! کد پیگیری برای شما :{rep.CodeGenerated}",
                        Errortype = "Error"
                    };
                    ViewBag.EXLogin = ModelSender;
                    return Json(ModelSender);
                }

            }
            else
            {
                List<ModelErrorReporter> allErrors = new List<ModelErrorReporter>();
                //foreach (ModelError error in ModelState.Values.)
                var AllValues = ModelState.Values.ToList();
                var AllKeys = ModelState.Keys.ToList();
                int errorsCount = AllValues.Count;
                for (int i = 0; i < errorsCount; i++)
                {
                    if (AllValues[i].Errors.Count > 0)
                    {
                        ModelErrorReporter er = new ModelErrorReporter()
                        {
                            IdOfProperty = AllKeys[i].Replace("administrator.", "administrator_"),
                            ErrorMessage = AllValues[i].Errors[0].ErrorMessage
                        };
                        allErrors.Add(er);
                    }
                }
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX104",
                    Errormessage = $"عدم رعایت استاندارد ها!",
                    Errortype = "ErrorWithList",
                    AllErrors = allErrors
                };
                return Json(ModelSender);

            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeAuthInformations(ChangeProfileModel informations)
        {
            changeAuthInformation information = informations.authInformation;
            if (ModelState.IsValid)
            {
                string adminID = "";
                try
                {
                    adminID = ((Administrator)Session["AdministratorRegistery"]).id_Admin;
                }
                catch (Exception exception)
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.sessionAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj1)}")
                    {
                        EXOBJ = exception
                    };
                }
                //If Session Doesent work 
                try
                {
                    HttpCookie cookie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCoockieCode());
                    adminID = CoockieController.SayMyName(cookie.Value).id_Admin;
                }
                catch (Exception EX)
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.coockieAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj1)}")
                    {
                        EXOBJ = EX
                    };
                }
                if (string.IsNullOrEmpty(adminID))
                {
                    adminID = "NO-ID";
                }
                PDBC db = new PDBC();
                List<ExcParameters> dbparams = new List<ExcParameters>();
                ExcParameters param = new ExcParameters()
                {
                    _VALUE = adminID,
                    _KEY = "@id_Admin"
                };
                dbparams.Add(param);
                db.Connect();
                using (DataTable dt = db.Select("SELECT [ad_password] FROM [tbl_ADMIN_main] WHERE [id_Admin] = @id_Admin", dbparams))
                {
                    db.DC();
                    if (dt.Rows.Count > 0)
                    {
                        EncDec en = new EncDec();
                        string md5GeneratedPW = en.HMACMD5Generator(information.OLDpassword);
                        if (md5GeneratedPW == dt.Rows[0]["ad_password"].ToString())
                        {
                            if (string.IsNullOrEmpty(information.Newpassword1))
                            {
                                param = new ExcParameters()
                                {
                                    _VALUE = information.Username,
                                    _KEY = "@ad_username"
                                };
                                dbparams.Add(param);
                                db.Connect();
                                string result = db.Script("UPDATE [tbl_ADMIN_main] SET [ad_username] = @ad_username WHERE [id_Admin] = @id_Admin", dbparams);
                                db.DC();
                                if (result == "1")
                                {

                                    try
                                    {
                                        var sessionChanger = (Administrator)Session["AdministratorRegistery"];
                                        sessionChanger.Username = information.Username;
                                        Session["AdministratorRegistery"] = sessionChanger;
                                    }
                                    catch (Exception EX)
                                    {
                                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.sessionAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj LINE 298)}")
                                        {
                                            EXOBJ = EX
                                        };
                                    }
                                    try
                                    {
                                        HttpCookie cookie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCoockieCode());
                                        var sessionChanger = CoockieController.SayMyName(cookie.Value);
                                        sessionChanger.Username = information.Username;
                                        var userCookieIDV = new HttpCookie(ProjectProperies.AuthCoockieCode());
                                        userCookieIDV.Value = CoockieController.SetCoockie(sessionChanger); ;
                                        userCookieIDV.Expires = DateTime.Now.AddYears(5);
                                        Response.SetCookie(userCookieIDV);
                                    }
                                    catch (Exception EX)
                                    {
                                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.coockieAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj LINE 315)}")
                                        {
                                            EXOBJ = EX
                                        };
                                    }
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "SX102",
                                        Errormessage = "نام کاربری با موفقیت ویرایش شد!",
                                        Errortype = "Success"
                                    };
                                    return Json(ModelSender);
                                }
                                else
                                {
                                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX108",
                                        Errormessage = "عدم توانایی در ایجاد نشست فعال برای شما با پشتیبانی تماس حاصل فرمایید",
                                        Errortype = "Error"
                                    };
                                    return Json(ModelSender);
                                }
                            }
                            else
                            {
                                if (information.Newpassword1 == information.Newpassword2)
                                {
                                    param = new ExcParameters()
                                    {
                                        _VALUE = information.Username,
                                        _KEY = "@ad_username"
                                    };
                                    dbparams.Add(param);
                                    param = new ExcParameters()
                                    {
                                        _VALUE = md5GeneratedPW,
                                        _KEY = "@ad_password"
                                    };
                                    dbparams.Add(param);
                                    db.Connect();
                                    string result = db.Script("UPDATE  [tbl_ADMIN_main] SET [ad_password] = @ad_password,[ad_username] = @ad_username  WHERE [id_Admin] = @id_Admin", dbparams);
                                    db.DC();
                                    if (result == "1")
                                    {
                                        try
                                        {
                                            var sessionChanger = (Administrator)Session["AdministratorRegistery"];
                                            sessionChanger.Username = information.Username;
                                            Session["AdministratorRegistery"] = sessionChanger;
                                        }
                                        catch (Exception EX)
                                        {
                                            PPBugReporter rep = new PPBugReporter(BugTypeFrom.sessionAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj LINE 126)}")
                                            {
                                                EXOBJ = EX
                                            };
                                        }
                                        try
                                        {
                                            HttpCookie cookie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCoockieCode());
                                            var sessionChanger = CoockieController.SayMyName(cookie.Value);
                                            sessionChanger.Username = information.Username;
                                            var userCookieIDV = new HttpCookie(ProjectProperies.AuthCoockieCode());
                                            userCookieIDV.Value = CoockieController.SetCoockie(sessionChanger); ;
                                            userCookieIDV.Expires = DateTime.Now.AddYears(5);
                                            Response.SetCookie(userCookieIDV);
                                        }
                                        catch (Exception EX)
                                        {
                                            PPBugReporter rep = new PPBugReporter(BugTypeFrom.coockieAuth, "IN Controller : {AdministratorGeneralController}\nMethod : {public ActionResult Index(ChangeProfileModel adObj LINE 126)}")
                                            {
                                                EXOBJ = EX
                                            };
                                        }


                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "SX103",
                                            Errormessage = "اطلاعات ورود با موفقیت ویرایش شد!",
                                            Errortype = "Success"
                                        };
                                        return Json(ModelSender);
                                    }
                                    else
                                    {
                                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "EX110",
                                            Errormessage = $"عدم توانایی در ویرایش اطلاعات با پشتیبانی تماس حاصل فرمایید! کد پیگیری برای شما :{rep.CodeGenerated}",
                                            Errortype = "Error"
                                        };
                                        return Json(ModelSender);
                                    }
                                }
                                else
                                {
                                    List<ModelErrorReporter> allErrors = new List<ModelErrorReporter>();
                                    ModelErrorReporter er = new ModelErrorReporter()
                                    {

                                        IdOfProperty = "authInformation_Newpassword1",
                                        ErrorMessage = "عدم یکسانی کلمه های عبور"
                                    };
                                    allErrors.Add(er);
                                    er = new ModelErrorReporter()
                                    {
                                        IdOfProperty = "authInformation_Newpassword2",
                                        ErrorMessage = "عدم یکسانی کلمه های عبور"
                                    };
                                    allErrors.Add(er);
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX109",
                                        Errormessage = "عدم یکسانی کلمه های عبور",
                                        Errortype = "ErrorWithList",
                                        AllErrors = allErrors

                                    };
                                    return Json(ModelSender);
                                }
                            }
                        }
                        else
                        {
                            List<ModelErrorReporter> allErrors = new List<ModelErrorReporter>();
                            ModelErrorReporter er = new ModelErrorReporter()
                            {
                                IdOfProperty = "authInformation_OLDpassword",
                                ErrorMessage = "کلمه عبور بدرستی وارد نشده است"
                            };
                            allErrors.Add(er);
                            var ModelSender = new ErrorReporterModel
                            {
                                ErrorID = "EX105",
                                Errormessage = $"کلمه عبور حال شما کلید شما برای ایجاد تغییرات میباشد",
                                Errortype = "ErrorWithList",
                                AllErrors = allErrors
                            };
                            return Json(ModelSender);
                        }
                    }
                    else
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX107",
                            Errormessage = $"کاربر یافت نشد با پشتیبانی تماس بفرمایید",
                            Errortype = "Error",
                        };
                        return Json(ModelSender);
                    }
                }
            }
            else
            {
                List<ModelErrorReporter> allErrors = new List<ModelErrorReporter>();
                var AllValues = ModelState.Values.ToList();
                var AllKeys = ModelState.Keys.ToList();
                int errorsCount = AllValues.Count;
                for (int i = 0; i < errorsCount; i++)
                {
                    if (AllValues[i].Errors.Count > 0)
                    {
                        ModelErrorReporter er = new ModelErrorReporter()
                        {
                            IdOfProperty = AllKeys[i].Replace("authInformation.", "authInformation_"),
                            ErrorMessage = AllValues[i].Errors[0].ErrorMessage
                        };
                        allErrors.Add(er);
                    }
                }
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX106",
                    Errormessage = $"عدم رعایت استاندارد ها!",
                    Errortype = "ErrorWithList",
                    AllErrors = allErrors
                };
                return Json(ModelSender);
            }
        }


        //====================================================================Need To backend
        public ActionResult AddAdmin()
        {
            return View();
        }

        public ActionResult ShowAdmins()
        {
            return View();
        }
        public ActionResult AdminsProfile()
        {
            return View();
        }
    }
}
