using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorWorkplaceController : AdminRulesController
    {
        // GET: AdministratorWorkplace
        //Widgets Is Here
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchResult(string query)
        {
            return View();
        }
        //Widgets will write here

    }
}