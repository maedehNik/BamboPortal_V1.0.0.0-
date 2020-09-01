using BamboPortal_V1._0._0._0.Models.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide;
using BamboPortal_V1._0._0._0.StaticClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class CustomerSide_CustomerRuleController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.RouteData.Values["action"].ToString();
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            AllowDisallow AA = new AllowDisallow()
            {
                BasketItemsCount = 0,
                ShoppingBasket = new ShoppingBasket()
                {
                    Items = new List<ShoppingBasketItems>()
                }
            };
            ShoppingBasket model = new ShoppingBasket();
            if (HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket()) != null)
            {
                model = JsonConvert.DeserializeObject<ShoppingBasket>(HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket()).Value);
            }
            else
            {
                model = new ShoppingBasket()
                {
                    Items = new List<ShoppingBasketItems>()
                };
            }
            AA.ShoppingBasket = model;
            AA.BasketItemsCount = model.Items.Count;
            ViewBag.AllAllowDisallow = AA;
            if (coockie != null)
            {
                tcm = CoockieController.SayWhoIsHE(coockie.Value);
                var Id = tcm.id_Customer;
                int dd = 0;
                if (Int32.TryParse(Id, out dd))
                {
                    ViewBag.IsUserLogin = true;
                }
                else
                {
                    ViewBag.IsUserLogin = false;
                }
            }
            else
            {
                ViewBag.IsUserLogin = false;
            }


            base.OnActionExecuting(filterContext);

        }
    }
}