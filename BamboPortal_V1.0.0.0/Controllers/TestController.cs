using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            AddDataToDataBase add = new AddDataToDataBase();
            return Content(add.AddData());
        }
    }
}