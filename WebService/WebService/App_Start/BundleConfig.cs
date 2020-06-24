using System.Web;
using System.Web.Optimization;

namespace WebService
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Js").Include(
                      "~/Content/bower_components/jquery/dist/jquery.min.js",
                      "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                      "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                      "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                      // "~/Content/bower_components/jquery-ui/jquery-ui.min.js",
                      "~/Content/bower_components/fastclick/lib/fastclick.js",
                      "~/Content/dist/js/adminlte.min.js",
                      "~/Content/dist/js/demo.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jquery.bootgrid.fa.js",
                      "~/Scripts/jquery.bootgrid.fa.min.js",
                      "~/Scripts/jquery.bootgrid.js",
                      "~/Scripts/jquery.bootgrid.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Css").Include(
                    "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                    "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                    "~/Content/dist/css/skins/_all-skins.min.css",
                    "~/Content/dist/css/AdminLTE.min.css",
                    "~/Content/bower_components/Ionicons/css/ ionicons.min.css",
                    "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                    "~/Content/jquery.bootgrid.css",
                    "~/Content/jquery.bootgrid.min.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/themes/base").Include(
              "~/Content/themes/base/core.css",
              "~/Content/themes/base/resizable.css",
              "~/Content/themes/base/selectable.css",
              "~/Content/themes/base/accordion.css",
              "~/Content/themes/base/autocomplete.css",
              "~/Content/themes/base/button.css",
              "~/Content/themes/base/dialog.css",
              "~/Content/themes/base/slider.css",
              "~/Content/themes/base/tabs.css",
              "~/Content/themes/base/datepicker.css",
              "~/Content/themes/base/progressbar.css",
              "~/Content/themes/base/theme.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
