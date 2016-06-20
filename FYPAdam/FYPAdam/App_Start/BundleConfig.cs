using System.Web;
using System.Web.Optimization;

namespace FYPAdam
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-1.11.0.min.js",
                        "~/Scripts/jquery-scrolltofixed.js",
                        "~/Scripts/jquery.nav.js", 
                        "~/Scripts/jquery.easing.1.3.js", 
                        "~/Scripts/jquery.isotope.js", 
                        "~/Scripts/fancybox/jquery.fancybox.pack.js", 
                        "~/Scripts/wow.js",
                        "~/Scripts/jquery.reveal.js",
                        "~/Scripts/plugins/flot/jquery.reveal.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                "~/Content/bootstrap.min.css",
                "~/Scripts/fancybox/jquery.fancybox.css",
                "~/font-awesome/css/style.css",
                "~/font-awesome/css/font-awesome.css",
                "~/font-awesome/css/animate.css",
                "~/Content/Custom.css",
                "~/Content/reveal.css",
                "~/Content/External/dist/css/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}