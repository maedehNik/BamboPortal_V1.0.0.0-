using System.Configuration;
using System.Web;
using System.Web.Optimization;

namespace BamboPortal_V1._0._0._0
{
    public class SiteKeys
    {
        public static string StyleVersion
        {
            get
            {
                return "<link href=\"{0}?v=" + ConfigurationManager.AppSettings["adminpanelassetsversion"] + "\" rel=\"stylesheet\"/>";
            }
        }
        public static string ScriptVersion
        {
            get
            {
                return "<script src=\"{0}?v=" + ConfigurationManager.AppSettings["adminpanelassetsversion"] + "\"></script>";
            }
        }
    }
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
             BundleTable.EnableOptimizations = false;

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //Bundles {Start} : Global Theme Bundle
            bundles.Add(new ScriptBundle("~/bundles/MetronicGlobalThemeBundle.js").Include(
              "~/AdminDesignResource/vendors/base/vendors.bundle.js",
              "~/AdminDesignResource/demo/default/base/scripts.bundle.js"));
            bundles.Add(new StyleBundle("~/Content/MetronicGlobalThemeBundle.css").Include(
                      "~/AdminDesignResource/vendors/base/vendors.bundle.rtl.css",
                      "~/AdminDesignResource/demo/default/base/style.bundle.rtl.css"));
            //Bundles {End} : Global Theme Bundle

            //Bundles {Start} : Page Scripts --> LoginPage
            bundles.Add(new ScriptBundle("~/bundles/MetronicPageScripts_LOGIN.js").Include(
              "~/AdminDesignResource/snippets/custom/pages/user/login.js",
              "~/AdminDesignResource/snippets/custom/pages/user/validate-login.js"));
            //Bundles {End} : Page Scripts --> LoginPage
            //Bundles {Start} : Page Scripts --> Dashboard
            bundles.Add(new ScriptBundle("~/bundles/Dashboard.js").Include(
                "~/AdminDesignResource/vendors/custom/fullcalendar/fullcalendar.bundle.js",
                "~/AdminDesignResource/app/js/dashboard.js",
                "~/AdminDesignResource/vendors/jquery.min.js",
                "~/AdminDesignResource/custom-js.js"));

            bundles.Add(new StyleBundle("~/Content/Dashboard.css").Include(
                "~/AdminDesignResource/vendors/custom/fullcalendar/fullcalendar.bundle.rtl.css",
                "~/AdminDesignResource/vendors/custom/custom-css.css"));
            //Bundles {END} : Page Scripts --> Dashboard
            //Bundles {Start} : Page Scripts --> AdminProfile
            bundles.Add(new ScriptBundle("~/bundles/AdminProfile.js").Include(
                "~/AdminDesignResource/demo/default/custom/header/actions.js",
                "~/AdminDesignResource/vendors/jquery.min.js",
                "~/AdminDesignResource/custom-js.js"));
            //Style Uses Dashboard styles
            //Bundles {END} : Page Scripts --> AdminProfile

        }
    }
}
