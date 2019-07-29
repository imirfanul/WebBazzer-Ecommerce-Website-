using System.Web;
using System.Web.Optimization;

namespace WebBazzer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Contents/css").Include(
                      "~/Contents/css/bootstrap.min.css",
                      "~/Contents/css/sb-admin.css",
                      "~/Contents/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/Contents/js").Include(
              "~/Contents/js/jquery.js",
              "~/Contents/js/bootstrap.min.js",
              "~/Contents/js/MyCustom.js"
              ));

            bundles.Add(new ScriptBundle("~/Contents/js").Include(
             "~/Contents/js/jquery-2.0.0.min.js",
             "~/Contents/js/bootstrap.min.js",
             "~/Contents/js/MyCustom.js",
             "~/Contents/js/jquery.validate.min.js",
             "~/Contents/js/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/Contents/js/plugins").Include(
            "~/Contents/js/plugins/morris/raphael.min.js",
            "~/Contents/js/plugins/morris/morris.min.js",
            "~/Contents/js/plugins/morris/morris-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/css/font-awesome.css",
                     "~/Content/css/bootstrap.css",
                     "~/Content/css/jquery.smartmenus.bootstrap.css",
                     "~/Content/css/jquery.simpleLens.css",
                     "~/Content/css/slick.css",
                     "~/Content/css/nouislider.css",
                     "~/Content/css/theme-color/green-theme.css",
                     "~/Content/css/sequence-theme.modern-slide-in.css",
                     "~/Content/css/style.css"));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                   "~/Content/js/jquery.unobtrusive-ajax.min.js",
                   "~/Content/js/bootstrap.js",
                   "~/Content/js/jquery.smartmenus.js",
                   "~/Content/js/jquery.smartmenus.bootstrap.js",
                   "~/Content/js/sequence.js",
                   "~/Content/js/sequence-theme.modern-slide-in.js",
                   "~/Content/js/jquery.simpleGallery.js",
                   "~/Content/js/jquery.simpleLens.js",
                   "~/Content/js/slick.js",
                   "~/Content/js/nouislider.js",
                   "~/Content/js/custom.js"
                  ));
            bundles.Add(new StyleBundle("~/ProductImageFile").Include(
                      "~/ProductImageFile"
                      ));
        }
    }
}
