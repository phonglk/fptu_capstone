using System.Web;
using System.Web.Optimization;

namespace DropIt
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/utils.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ko")
                .Include("~/Scripts/knockout-{version}.js",
                        "~/Scripts/custom-binding.js"));

            bundles.Add(new ScriptBundle("~/bundles/Admin")
                .IncludeDirectory("~/Scripts/Admin", "*.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));

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

            bundles.Add(new StyleBundle("~/Content/Admin")
                .Include("~/Content/Admin/css/bootstrap/bootstrap.css",
                            "~/Content/Admin/css/bootstrap/bootstrap-responsive.css",
                            "~/Content/Admin/css/bootstrap/bootstrap-overrides.css")
                .Include("~/Content/Admin/css/lib/jquery-ui-1.10.2.custom.css")
                .Include("~/Content/Admin/css/lib/font-awesome/css/font-awesome.css",
                            "~/Content/Admin/css/compiled/layout.css",
                            "~/Content/Admin/css/elements.css",
                            "~/Content/Admin/css/icons.css",
                            "~/Content/Admin/font/OpenSans.css",
                            "~/Content/Admin/font/Lato.css"));
        }
    }
}