using BamboPortal_V1._0._0._0.Models.CustomerSide;
using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class CustomerSide_CustomerProfileRuleController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.RouteData.Values["action"].ToString();
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            if (coockie != null)
            {
                tcm = CoockieController.SayWhoIsHE(coockie.Value);
                var Id = tcm.id_Customer;
                int dd = 0;
                if (Int32.TryParse(Id, out dd))
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    filterContext.Result = RedirectToAction("loginandregister", "CustomerSide_Register");
                }
            }
            else
            {
                filterContext.Result = RedirectToAction("loginandregister", "CustomerSide_Register");
            }
        }
    }
}