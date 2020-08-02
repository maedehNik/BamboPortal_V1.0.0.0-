using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class CustomerSide_BlogController : CustomerSide_BlogRuleController
    {
        // GET: CustomerSide_Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}