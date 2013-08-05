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
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.validate").Include(
                        
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/jtable").Include(
                        "~/Scripts/jtable/jquery.jtable.js",
                        "~/Scripts/jtable/localization/jquery.jtable.vi.js",
                        "~/Scripts/jtable/jtable.dropit.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap/bootstrap.js",
                        "~/Scripts/bootstrap/bootstrap-modalmanager.js",
                        "~/Scripts/bootstrap/bootstrap-modal.js",
                        "~/Scripts/bootstrap/datetimepicker/bootstrap-datetimepicker.js",
                        "~/Scripts/select2/select2.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                        "~/Scripts/select2/select2.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/ko")
                .Include("~/Scripts/knockout-{version}.js",
                        "~/Scripts/Common/custom-binding.js"));

            bundles.Add(new ScriptBundle("~/bundles/Admin")
                .Include(
                "~/Content/dialog2/lib/jquery.dialog2.js",
                "~/Content/dialog2/lib/jquery.dialog2.helpers.js",
                "~/Scripts/Admin/default.js"));

            bundles.Add(new ScriptBundle("~/bundles/utils")
                .Include(
                "~/Scripts/jquery.format.date.js",
                "~/Scripts/Common/utils.js",
                "~/Scripts/Common/utilClasses.js"));

            bundles.Add(new ScriptBundle("~/bundles/utils-admin")
                .Include(
                "~/Scripts/jquery.format.date.js",
                "~/Scripts/Common/utils.js",
                "~/Scripts/Common/utilClasses.js"));

            bundles.Add(new ScriptBundle("~/bundles/ve").Include(
                "~/Scripts/ValidationEngine/jquery.validationEngine-dropit.js",
                "~/Scripts/ValidationEngine/jquery.validationEngine.js"
                ));

            // script admin
            bundles.Add(new ScriptBundle("~/bundles/Themes/Plastique").Include(
                "~/Content/themes/plastique/javascripts/application.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/DropIt")
               .IncludeDirectory("~/Scripts/DropIt", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //style admin
            bundles.Add(new StyleBundle("~/Content/Themes/Plastique")
                .Include("~/Content/themes/plastique/stylesheets/application.css"));

            bundles.Add(new StyleBundle("~/Content/DropIt")
                .Include("~/Content/Admin/css/bootstrap/bootstrap.css", 
                            "~/Content/Admin/css/lib/font-awesome/css/font-awesome.css",
                            "~/Content/Admin/font/OpenSans.css",
                            "~/Scripts/bootstrap/datetimepicker/bootstrap-datetimepicker.css",
                            "~/Scripts/select2/select2.css",
                            "~/Content/DropIt/css/bootstrap-fix.css",
                            "~/Content/default.css",
                            "~/Content/DropIt/css/new.css"));

            bundles.Add(new StyleBundle("~/Content/select2")
                .Include(
                            "~/Scripts/select2/select2.css"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui")
                .Include("~/Content/jquery-ui-bootstrap/jquery-ui-1.10.0.custom.css"));

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

            bundles.Add(new StyleBundle("~/Content/jtable").Include(
                        "~/Scripts/jtable/themes/metro/blue/jtable.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                    .Include("~/Content/Admin/css/bootstrap/bootstrap.css",
                            "~/Content/Admin/css/bootstrap/bootstrap-responsive.css",
                            "~/Content/Admin/css/bootstrap/bootstrap-overrides.css",
                            "~/Content/bootstrap-modal/css/bootstrap-modal.css",
                            "~/Scripts/bootstrap/datetimepicker/bootstrap-datetimepicker.css",
                            "~/Scripts/select2/select2.css"
                            ));

            bundles.Add(new StyleBundle("~/Content/Admin")
                .Include(
                "~/Content/dialog2/css/jquery-dialog2/jquery.dialog2.css",
                "~/Content/Admin/admin.css"));

            bundles.Add(new StyleBundle("~/Content/ve")
                    .Include("~/Scripts/ValidationEngine/validationEngine.jquery.css"));
        }
    }
}