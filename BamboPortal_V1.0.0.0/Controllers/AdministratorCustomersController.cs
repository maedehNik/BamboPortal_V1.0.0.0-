using System;
using System.Collections.Generic;
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
    }
}