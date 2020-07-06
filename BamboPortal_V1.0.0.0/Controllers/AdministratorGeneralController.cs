using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.MasterObjetsModel;
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
        [AdministratorValidation]
        public ActionResult Index(Administrator adObj)
        {
            if (ModelState.IsValid)
            {
                string adminID = ((Administrator)Session["AdministratorRegistery"]).id_Admin;
                PDBC db = new PDBC();
                List<ExcParameters> dbparams = new List<ExcParameters>();
                adObj.ad_avatarprofile = UploaderGeneral.imageFinder(adObj.ad_avatarPicIDfromUploader);
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
                    var sessionChanger = (Administrator)Session["AdministratorRegistery"];
                    sessionChanger.ad_avatarprofile = adObj.ad_avatarprofile;
                    sessionChanger.ad_NickName = adObj.ad_NickName;
                    sessionChanger.ad_firstname = adObj.ad_firstname;
                    sessionChanger.ad_lastname = adObj.ad_lastname;
                    sessionChanger.ad_email = adObj.ad_email;
                    sessionChanger.ad_phone = adObj.ad_phone;
                    sessionChanger.ad_mobile = adObj.ad_mobile;
                    Session["AdministratorRegistery"] = sessionChanger;


                    ProfileProperty propfileinfo = new ProfileProperty()
                    {
                        avatarImageSrc = ((Administrator)Session["AdministratorRegistery"]).ad_avatarprofile,
                        name = ((Administrator)Session["AdministratorRegistery"]).ad_NickName,
                        fullname = ((Administrator)Session["AdministratorRegistery"]).ad_firstname + " " + ((Administrator)Session["AdministratorRegistery"]).ad_lastname,
                        ipAdmin = Request.UserHostAddress,
                        Firstname = ((Administrator)Session["AdministratorRegistery"]).ad_firstname,
                        Lastname = ((Administrator)Session["AdministratorRegistery"]).ad_lastname,
                        email = ((Administrator)Session["AdministratorRegistery"]).ad_email,
                        phone = ((Administrator)Session["AdministratorRegistery"]).ad_phone,
                        mobile = ((Administrator)Session["AdministratorRegistery"]).ad_mobile

                    };
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX101",
                        Errormessage = "اطلاعات کاربری با موفقیت ویرایش شد!",
                        Errortype = "Success"
                    };
                    ViewBag.EXLogin = ModelSender;
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX104",
                        Errormessage = $"عدم توانایی در ویرایش اطلاعات با پشتیبانی تماس حاصل فرمایید! کد پیگیری برای شما :{rep.CodeGenerated}",
                        Errortype = "Error"
                    };
                    ViewBag.EXLogin = ModelSender;
                    return Json(ModelSender);
                }

            }
            else
            {
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX104",
                    Errormessage = $"عدم توانایی در ویرایش اطلاعات با پشتیبانی تماس حاصل فرمایید! ",
                    Errortype = "Error"
                };
                return Json(ModelSender);

            }
        }
    }
}