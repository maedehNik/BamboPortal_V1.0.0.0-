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
            //Bundles {Start} : Page Scripts --> CustomerSide
            bundles.Add(new ScriptBundle("~/bundles/CustomerSide.js").Include(
               "~/CustomerSide_desinerResource/third-party/jquery/jquery.min.js",
               "~/CustomerSide_desinerResource/third-party/easing/js/jquery.easings.min.js",
               "~/CustomerSide_desinerResource/third-party/bootstrap/js/bootstrap.min.js",
               "~/CustomerSide_desinerResource/third-party/nivo-lightbox/js/nivo-lightbox.min.js",
               "~/CustomerSide_desinerResource/third-party/owl/owl.carousel.js",
               "~/CustomerSide_desinerResource/third-party/isotope/js/isotope.pkgd.min.js",
               "~/CustomerSide_desinerResource/third-party/counter-up/js/jquery.counterup.min.js",
               "~/CustomerSide_desinerResource/third-party/form-validation/js/formValidation.js",
               "~/CustomerSide_desinerResource/third-party/form-validation/js/framework/bootstrap.min.js",
               "~/CustomerSide_desinerResource/third-party/waypoint/js/waypoints.min.js",
               "~/CustomerSide_desinerResource/third-party/wow/js/wow.min.js",
               "~/CustomerSide_desinerResource/third-party/jquery-actual/js/jquery.actual.min.js",
               "~/CustomerSide_desinerResource/third-party/smooth-scroll/js/smoothScroll.js",
               "~/CustomerSide_desinerResource/third-party/jquery-parallax/js/jquery.parallax.js",
               "~/CustomerSide_desinerResource/third-party/jquery-parallax/js/jquery.localscroll.min.js",
               "~/CustomerSide_desinerResource/third-party/jquery-parallax/js/jquery.scrollTo.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/jquery.themepunch.tools.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/jquery.themepunch.revolution.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.actions.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.carousel.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.kenburn.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.layeranimation.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.migration.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.navigation.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.parallax.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.slideanims.min.js",
               "~/CustomerSide_desinerResource/third-party/revolution/js/extensions/revolution.extension.video.min.js"));

            bundles.Add(new StyleBundle("~/Content/CustomerSide.css").Include(
               "~/CustomerSide_desinerResource/third-party/bootstrap/css/bootstrap.min.css",
               "~/CustomerSide_desinerResource/third-party/font-awesome/css/font-awesome.min.css",
               "~/CustomerSide_desinerResource/third-party/et-line/css/style.css",
               "~/CustomerSide_desinerResource/third-party/elegant-icons/css/style.css",
               "~/CustomerSide_desinerResource/third-party/pe-icon-7-stroke/css/pe-icon-7-stroke.css",
               "~/CustomerSide_desinerResource/third-party/pe-icon-7-stroke/css/helper.css",
               "~/CustomerSide_desinerResource/third-party/nivo-lightbox/css/nivo-lightbox.css",
               "~/CustomerSide_desinerResource/third-party/nivo-lightbox/themes/default/default.css",
               "~/CustomerSide_desinerResource/third-party/animate/css/animate.css",
               "~/CustomerSide_desinerResource/third-party/owl/assets/owl.carousel.css",
               "~/CustomerSide_desinerResource/third-party/owl/assets/owl.theme.default.css",
               "~/CustomerSide_desinerResource/third-party/form-validation/css/formValidation.min.css",
               "~/CustomerSide_desinerResource/third-party/revolution/css/settings.css",
               "~/CustomerSide_desinerResource/third-party/revolution/css/layers.css",
               "~/CustomerSide_desinerResource/third-party/revolution/css/navigation.css",
               "~/CustomerSide_desinerResource/css/style.css",
               "~/CustomerSide_desinerResource/css/custom.css",
               "~/CustomerSide_desinerResource/css/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/CustomerSide2.js").Include(
               "~/CustomerSide_desinerResource/js/scripts.js",
               "~/CustomerSide_desinerResource/js/custom.js"));
            //Bundles {END} : Page Scripts --> CustomerSide

            //Bundles {Start} : Page Scripts --> CustomerSide_Index
            bundles.Add(new ScriptBundle("~/bundles/CustomerSideIndex.js").Include(
              "~/CustomerSide_desinerResource/js/jquery-ui.min.js",
              "~/CustomerSide_desinerResource/js/jquery.validate.js"));
            //Bundles {END} : Page Scripts --> CustomerSide_Index

            //Bundles {Start} : Page Scripts --> CustomerSide_UserProfile
            bundles.Add(new ScriptBundle("~/bundles/CustomerSideUserProfile.js").Include(
              "~/CustomerSide_desinerResource/js/jquery.validate.js"));
            //Bundles {END} : Page Scripts --> CustomerSide_UserProfile


            //Bundles {Start} : Page Scripts --> CustomerSide_UI
            bundles.Add(new ScriptBundle("~/bundles/CustomerSideUI.js").Include(
              "~/CustomerSide_desinerResource/js/jquery-ui.min.js"));
            //Bundles {END} : Page Scripts --> CustomerSide_UserProfile

            //Bundles {Start} : Page Scripts --> UploaderModules
            bundles.Add(new ScriptBundle("~/bundles/Uploader.js").Include(
              //"~/AdminDesignResource/vendors/custom/custom-js.js",
              "~/AdminDesignResource/app/js/uploader.js"));
            //Bundles {END} : Page Scripts --> UploaderModules
            BundleTable.EnableOptimizations = false;



        }
    }
}
