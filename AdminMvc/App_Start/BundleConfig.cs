using System.Web;
using System.Web.Optimization;

namespace AdminMvc
{
    // Gather files in bundles for easy injection in views
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            bundles.Add(new ScriptBundle("~/Scripts").Include(
                        "~/Scripts/vars.js",
                        "~/Scripts/main.js"));

            // Styles
            bundles.Add(new StyleBundle("~/Content").Include(
                      "~/Content/home.css"));
        }
    }
}
