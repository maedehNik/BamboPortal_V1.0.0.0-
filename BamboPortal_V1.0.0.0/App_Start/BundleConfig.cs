using System.Configuration;
using System.Web;
using System.Web.Optimization;

namespace BamboPortal_V1._0._0._0
{

    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Bundles {Start} : StockpileProductPage
            bundles.Add(new ScriptBundle("~/bundles/StockpileProductPage.js").Include(
                "~/AdminDesignResource/vendors/bootstrap-clockpicker.js",
              "~/AdminDesignResource/vendors/persianDatepicker.js"));

            bundles.Add(new StyleBundle("~/Content/StockpileProductPage.css").Include(
                      "~/AdminDesignResource/vendors/bootstrap-clockpicker.css",
                      "~/AdminDesignResource/vendors/persianDatepicker-default.css"));
            //Bundles {End} : StockpileProductPage

            //Bundles {Start} : Global Theme Bundle
            bundles.Add(new ScriptBundle("~/bundles/MetronicGlobalThemeBundle.js").Include(
                "~/AdminDesignResource/vendors/jquery.min.js",
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
                "~/AdminDesignResource/app/js/jqueryvalidate.js",
                "~/AdminDesignResource/app/js/adminPanelMainControllerJS.js"));
            //Style Uses Dashboard styles
            //Bundles {END} : Page Scripts --> AdminProfile
            bundles.Add(new ScriptBundle("~/bundles/Select2.js").Include(
    "~/AdminDesignResource/demo/default/custom/crud/forms/widgets/select2.js"));
            //Bundles {Start} : Page Scripts --> UploaderModules
            bundles.Add(new ScriptBundle("~/bundles/Uploader.js").Include(
              //"~/AdminDesignResource/vendors/custom/custom-js.js",
              "~/AdminDesignResource/app/js/uploader.js"));
            //Bundles {END} : Page Scripts --> UploaderModules

            //Bundles {Start} : Page Scripts --> Adminstrator_Customers
            bundles.Add(new ScriptBundle("~/bundles/AdminCustomer.js").Include(
              "~/AdminDesignResource/demo/default/custom/header/actions.js",
              "~/AdminDesignResource/vendors/custom/custom-js.js",
              "~/AdminDesignResource/app/js/Admin_Customers.js"));
            //Bundles {END} : Page Scripts --> Adminstrator_Customers

            //Bundles {Start} : Page Scripts --> Adminstrator_Customers_Profile
            bundles.Add(new ScriptBundle("~/bundles/AdminCustomerProf.js").Include(
              "~/AdminDesignResource/demo/default/custom/header/actions.js",
              "~/AdminDesignResource/vendors/custom/custom-js.js"));
            //Bundles {END} : Page Scripts --> Adminstrator_Customers_Profile

            //Bundles {Start} : Page Scripts --> Adminstrator_Blog
            bundles.Add(new ScriptBundle("~/bundles/AdminstratorBlog.js").Include(
              "~/AdminDesignResource/app/js/Admin_Blog.js"));
            //Bundles {END} : Page Scripts --> Adminstrator_Blog
            //========================================================================= END OF AdminPortal
            bundles.Add(new ScriptBundle("~/bundles/Customer1.js").Include(
                "~/resource/third-party/jquery/jquery.min.js",
                "~/resource/third-party/easing/js/jquery.easings.min.js",
                "~/resource/third-party/bootstrap/js/bootstrap.min.js",
                "~/resource/third-party/nivo-lightbox/js/nivo-lightbox.min.js",
                "~/resource/third-party/owl/owl.carousel.js",
                "~/resource/third-party/isotope/js/isotope.pkgd.min.js",
                "~/resource/third-party/counter-up/js/jquery.counterup.min.js",
                "~/resource/third-party/form-validation/js/formValidation.js",
                "~/resource/third-party/form-validation/js/framework/bootstrap.min.js",
                "~/resource/third-party/waypoint/js/waypoints.min.js",
                "~/resource/third-party/wow/js/wow.min.js",
                "~/resource/third-party/jquery-actual/js/jquery.actual.min.js",
                "~/resource/third-party/smooth-scroll/js/smoothScroll.js",
                "~/resource/third-party/jquery-parallax/js/jquery.parallax.js",
                "~/resource/third-party/jquery-parallax/js/jquery.localscroll.min.js",
                "~/resource/third-party/jquery-parallax/js/jquery.scrollTo.js",
                "~/resource/third-party/revolution/js/jquery.themepunch.tools.min.js",
                "~/resource/third-party/revolution/js/jquery.themepunch.revolution.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.actions.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.carousel.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.kenburn.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.migration.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.navigation.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.parallax.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.slideanims.min.js",
                "~/resource/third-party/revolution/js/extensions/revolution.extension.video.min.js"));

            bundles.Add(new StyleBundle("~/Content/Customer1.css").Include(
                     "~/resource/third-party/bootstrap/css/bootstrap.min.css",
                     "~/resource/third-party/font-awesome/css/font-awesome.min.css",
                     "~/resource/third-party/et-line/css/style.css",
                     "~/resource/third-party/elegant-icons/css/style.css",
                     "~/resource/third-party/pe-icon-7-stroke/css/pe-icon-7-stroke.css",
                     "~/resource/third-party/pe-icon-7-stroke/css/helper.css",
                     "~/resource/third-party/nivo-lightbox/css/nivo-lightbox.css",
                     "~/resource/third-party/nivo-lightbox/themes/default/default.css",
                     "~/resource/third-party/animate/css/animate.css",
                     "~/resource/third-party/owl/assets/owl.carousel.css",
                     "~/resource/third-party/owl/assets/owl.theme.default.css",
                     "~/resource/third-party/form-validation/css/formValidation.min.css",
                     "~/resource/third-party/revolution/css/settings.css",
                     "~/resource/third-party/revolution/css/layers.css",
                     "~/resource/third-party/revolution/css/navigation.css",
                     "~/resource/css/jquery-ui.css",
                     "~/resource/css/style.css",
                     "~/resource/css/custom.css"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/Customer2.js").Include(
  "~/resource/js/jquery-ui.min.js",
  "~/resource/js/jquery.validate.js",
  "~/resource/js/scripts.js",
  "~/resource/js/custom.js"
  ));

            BundleTable.EnableOptimizations = false;



        }
    }
}
