using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bottom-jquery").Include(
                "~/Scripts/jquery-easing-1.3.js"
                //"~/Scripts/jqBootstrapValidation.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/top-jquery").Include(
                "~/Scripts/jquery-2.1.4.min.js",
                "~/Scripts/jquery-ui-1.11.4.min.js",
                "~/Scripts/jquery-2.1.4.intellisense.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"

                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/cbpAnimatedHeader.min.js",
                      "~/Scripts/classie.js",
                      "~/Scripts/freelancer.js",
                      "~/Scripts/respond.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/freelancer.css",
                      "~/Content/pushpull.css",
                      "~/Content/site.css"));
        }
    }
}
