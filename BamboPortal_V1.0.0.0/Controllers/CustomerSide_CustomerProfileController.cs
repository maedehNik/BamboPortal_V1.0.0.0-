using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class CustomerSide_CustomerProfileController : CustomerSide_CustomerProfileRuleController
    {
        // GET: CustomerSide_CustomerProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}