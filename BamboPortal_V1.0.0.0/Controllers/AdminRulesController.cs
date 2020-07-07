using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.MasterObjetsModel;
using BamboPortal_V1._0._0._0.StaticClass;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdminRulesController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["AdministratorRegistery"] != null)
            {
                ProfileProperty propfileinfo = new ProfileProperty()
                {
                    avatarImageSrc = ((Administrator)Session["AdministratorRegistery"]).ad_avatarprofile,
                    name = ((Administrator)Session["AdministratorRegistery"]).ad_NickName,
                    fullname = ((Administrator)Session["AdministratorRegistery"]).ad_firstname + " " + ((Administrator)Session["AdministratorRegistery"]).ad_lastname,
                    ipAdmin = Request.UserHostAddress,
                    Firstname = ((Administrator)Session["AdministratorRegistery"]).ad_firstname,
                    Lastname = ((Administrator)Session["AdministratorRegistery"]).ad_lastname,
                    email = ((Administrator)Session["AdministratorRegistery"]).ad_email,
                    phone = ((Administrator)Session["AdministratorRegistery"]).ad_phone,
                    mobile = ((Administrator)Session["AdministratorRegistery"]).ad_mobile,
                    Username = ((Administrator)Session["AdministratorRegistery"]).Username

                };
                ViewBag.ProfileInfo = propfileinfo;
                //End of Admin Profile
                //start PAGE - TITLE
                string actionName = filterContext.RouteData.Values["action"].ToString();
                string controllerName = filterContext.RouteData.Values["controller"].ToString();
                ViewBag.pageTitle = TitleFounder.GetAdminPanelTitle(controllerName, actionName);
                //END of PAGE - TITLE


                base.OnActionExecuting(filterContext);
            }
            else if (HttpContext.Request.Cookies.Get(ProjectProperies.AuthCoockieCode()) != null)
            {
                var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCoockieCode());
                Administrator administratorobj = CoockieController.SayMyName(coockie.Value);

                if ((DateTime.Now - administratorobj.SayMyTime).TotalHours > 6)
                {
                    string actionName1 = filterContext.RouteData.Values["action"].ToString();
                    string controllerName1 = filterContext.RouteData.Values["controller"].ToString();
                    string urlRedirection = controllerName1 + "-A_" + actionName1;
                    if (!urlRedirection.Contains("AdminLoginAuth-A_index"))
                    {
                        TempData["urlRedirection"] = urlRedirection;
                        filterContext.Result = RedirectToAction("index", "AdminLoginAuth", new { @urlRedirection = urlRedirection });
                    }
                    else
                    {
                        filterContext.Result = RedirectToAction("index", "AdminLoginAuth");
                    }
                }

                ProfileProperty propfileinfo = new ProfileProperty()
                {
                    avatarImageSrc = administratorobj.ad_avatarprofile,
                    name = administratorobj.ad_NickName,
                    fullname = administratorobj.ad_firstname + " " + administratorobj.ad_lastname,
                    ipAdmin = Request.UserHostAddress,
                    Firstname = administratorobj.ad_firstname,
                    Lastname = administratorobj.ad_lastname,
                    email = administratorobj.ad_email,
                    phone = administratorobj.ad_phone,
                    mobile = administratorobj.ad_mobile,
                    Username = administratorobj.Username

                };
                administratorobj.SayMyTime = DateTime.Now;

                var userCookieIDV = new HttpCookie(ProjectProperies.AuthCoockieCode());
                userCookieIDV.Value = CoockieController.SetCoockie(administratorobj); ;
                userCookieIDV.Expires = DateTime.Now.AddYears(5);
                Response.SetCookie(userCookieIDV);

                ViewBag.ProfileInfo = propfileinfo;
                //End of Admin Profile
                //start PAGE - TITLE
                string actionName = filterContext.RouteData.Values["action"].ToString();
                string controllerName = filterContext.RouteData.Values["controller"].ToString();
                ViewBag.pageTitle = TitleFounder.GetAdminPanelTitle(controllerName, actionName);
                //END of PAGE - TITLE
                base.OnActionExecuting(filterContext);
            }
            else
            {
                string actionName = filterContext.RouteData.Values["action"].ToString();
                string controllerName = filterContext.RouteData.Values["controller"].ToString();
                string urlRedirection = controllerName + "-A_" + actionName;
                if (!urlRedirection.Contains("AdminLoginAuth-A_index"))
                {
                    TempData["urlRedirection"] = urlRedirection;
                    filterContext.Result = RedirectToAction("index", "AdminLoginAuth", new { @urlRedirection = urlRedirection });
                }
                else
                {
                    filterContext.Result = RedirectToAction("index", "AdminLoginAuth");
                }
            }
        }
    }
}