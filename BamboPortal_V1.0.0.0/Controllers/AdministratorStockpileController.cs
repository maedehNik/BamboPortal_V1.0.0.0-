using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorStockpileController : Controller
    {
        // GET: AdministratorStockpile
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProductInStockpile(int PSID)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetVarede()
        {
            return Json("");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetSadere()
        {
            return Json("");
        }
    }
}