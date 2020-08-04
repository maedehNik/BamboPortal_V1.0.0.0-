using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorCustomers;
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
    public class AdministratorCustomersController : AdminRulesController
    {
        // GET: AdministratorCustomers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            PDBC db = new PDBC();
            var res = new List<CustomerModel>();

            db.Connect();
            DataTable dt = db.Select("SELECT [id_Customer],[C_Mobile],[C_regDate],[C_FirstName] +' '+[C_LastNAme] as C_Name,[C_Description],[C_ISActivate] FROM [tbl_Customer_Main]");
            db.DC();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new CustomerModel()
                {
                    Num=i+1,
                    Id = Convert.ToInt32(dt.Rows[i]["id_Customer"]),
                    Name = dt.Rows[i]["C_Name"].ToString(),
                    Discription = dt.Rows[i]["C_Description"].ToString(),
                    Phone = dt.Rows[i]["C_Mobile"].ToString(),
                    IsActive = Convert.ToInt32(dt.Rows[i]["C_ISActivate"]),
                    Reg_Date= DateConvert.DateReturner(dt.Rows[i]["C_regDate"].ToString(), "ShortDate")
                };
                res.Add(model);
            }

            return View(res);
        }

        public ActionResult CustomerProfile(int id)
        {
            PDBC db = new PDBC();
            var AddresList = new List<AddressModel>();
            db.Connect();
            DataTable dt1 = db.Select("SELECT DISTINCT  B.[Ostan_name]  , B.[Shahr_Name] as city ,[C_AddressHint],[C_FullAddress] FROM [tbl_Customer_Address] as A inner join [tbl_Enum_Shahr] as B on A.ID_Shahr=B.ID_Shahr where A.id_Customer=" + id);

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                var model = new AddressModel()
                {
                    Num=i+1,
                    Ostan= dt1.Rows[i]["Ostan_name"].ToString(),
                    City = dt1.Rows[i]["city"].ToString(),
                    FullAddress = dt1.Rows[i]["C_FullAddress"].ToString(),
                    HintAddress = dt1.Rows[i]["C_AddressHint"].ToString()
                };
                AddresList.Add(model);
            }

            DataTable dt = db.Select("SELECT [id_Customer],[C_regDate],[C_Mobile],[C_FirstName],[C_LastNAme],[C_Description],[C_Email] FROM [tbl_Customer_Main]where id_Customer=" + id);
            db.DC();
            var res = new CustomerDetail();

            if (dt.Rows.Count != 0)
            {
                
                res.Id = Convert.ToInt32(dt.Rows[0]["id_Customer"]);
                res.Name = dt.Rows[0]["C_FirstName"].ToString();
                res.Familly = dt.Rows[0]["C_LastNAme"].ToString();
                res.Discription = dt.Rows[0]["C_Description"].ToString();
                res.PhoneNum = dt.Rows[0]["C_Mobile"].ToString();
                res.Email = dt.Rows[0]["C_Email"].ToString();
                res.registerDate = DateConvert.DateReturner(dt.Rows[0]["C_regDate"].ToString(), "ShortDate");
                res.Addresses = AddresList;
            }





            return View(res);
        }


        [HttpPost]
        public JsonResult User_Activate(string idToActive)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Customer_Main] SET [C_ISActivate] = 1,[C_ActivateDate] = GetDate() WHERE id_Customer=@id_PT", parss);
               
                db.DC();
                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این مشتری با موفقیت فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }

        [HttpPost]
        public JsonResult User_deActivate(string idTodeActive)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idTodeActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idTodeActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Customer_Main] SET [C_ISActivate] = 0 WHERE id_Customer= @id_PT", parss);

                db.DC();
                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این مشتری با موفقیت غیر فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }
    }
}