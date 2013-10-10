using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace BootstrapSupport
{
    public class BootstrapBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/moment.js",
                "~/Scripts/moment-datepicker.js"/*,
                "~/Scripts/jquery-migrate-1.1.1.js",
                "~/Scripts/jquery.validate.js",
                "~/scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.unobtrusive-custom-for-bootstrap.js"*/
                ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/bootstrap-mvc-validation.css",
                "~/Content/moment-datepicker/datepicker.css",
                "~/Content/body.css"
                ));
        }
    }
}