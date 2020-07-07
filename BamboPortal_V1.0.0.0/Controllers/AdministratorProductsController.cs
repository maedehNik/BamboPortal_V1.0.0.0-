using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorProductsController : AdminRulesController
    {
        // GET: AdministratorProducts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddType()
        {
            PDBC db = new PDBC();
            AddTypeModelView ATM = new AddTypeModelView();
            ATM.addtypeField = new addtype();
            ATM.TableAvailableProperty = new List<AddTypeTable>();
            ATM.TableDeletedProperties = new List<AddTypeTable>();



            if (Request.QueryString["tID"] != null)
            {
                List<ExcParameters> excParameters = new List<ExcParameters>();
                ExcParameters excParameter = new ExcParameters()
                {
                    _KEY = "@",
                    _VALUE = Request.QueryString["tID"].ToString()
                };
                db.Connect();
                using (DataTable dt = db.Select("", excParameters))
                {
                    db.DC();
                    if (dt.Rows.Count > 0)
                    {

                        addtype ad = new addtype()
                        {


                        };
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            else
            {

            }
            return View();
        }
        public ActionResult AddType(addtype senderObj)
        {



            return View();
        }

    }
}