using System;
using System.Configuration;
using System.Web.Optimization;

namespace SmartEvents.Web
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

      bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                  "~/Scripts/angular.js",
                  "~/Scripts/angular-ui/ui-bootstrap.js",
                  "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                  "~/Scripts/smart-table.js",
                  "~/Scripts/Directives/*.js",
                  "~/Scripts/Controllers/*.js"));

      bundles.Add(new ScriptBundle("~/bundles/infrastructure").Include(
                  "~/Scripts/Infrastructure/*.js"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap/bootstrap.min.css",
                "~/Content/flatly.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/bondsystem.min.css"));

      BundleTable.EnableOptimizations = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOptimizations"]);
    }
  }
}
