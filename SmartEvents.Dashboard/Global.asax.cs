using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SmartEvents.Infrastructure.Logging;

namespace TangOrganizer.Dashboard
{
  public class MvcApplication : HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    protected void Application_Error(object sender, EventArgs e)
    {
      return;
      var username = User.Identity.IsAuthenticated ? User.Identity.Name : "No user authenticated!";
      // Log controller exception
      Log.ErrorFormat("Username: '{0}'\nController: '{1}', Action: '{2}'.\nException: {3}",
        username,
        "",//context.RouteData.Values["controller"].ToString(),
        ""//context.RouteData.Values["action"].ToString(), JsonConvert.SerializeObject(context.Exception)
        );
    }

  }
}
