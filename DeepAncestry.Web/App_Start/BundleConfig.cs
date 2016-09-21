using System.Web;
using System.Web.Optimization;

namespace DeepAncestry.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/libs/modernizr-2.6.2.js",
                        "~/Scripts/libs/angular.min.js",
                        "~/Scripts/libs/jquery-1.10.2.min.js",
                        "~/Scripts/libs/angular-route.min.js",
                        "~/Scripts/libs/angular-resource.min.js",
                        "~/Scripts/libs/bootstrap.min.js",
                        "~/Scripts/libs/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/build/src.js"));

            bundles.Add(new StyleBundle("~/Content/libs").Include(
                      "~/Content/libs/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/app").Include(
                      "~/Content/build/app.css"));

        }
    }
}
