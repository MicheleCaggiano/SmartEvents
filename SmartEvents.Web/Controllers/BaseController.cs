using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SmartEvents.Infrastructure.Logging.Interfaces;

namespace SmartEvents.Web.Controllers
{
  public class BaseController : Controller
  {
    private readonly ILogger _logger;

    public ILogger Log
    {
      get { return _logger; }
    }

    public BaseController()
    {
      _logger = UnityConfig.GetConfiguredContainer().Resolve<ILogger>();
    }

    protected override void OnException(ExceptionContext context)
    {
      // Log controller exception
      Log.ErrorFormat("Controller '{0}', Action: '{1}'. Exception: {2}",
        context.RouteData.Values["controller"].ToString(),
        context.RouteData.Values["action"].ToString(), JsonConvert.SerializeObject(context.Exception));
    }

    public ActionResult GetJson<TEntity>(TEntity obj)
    {
      var settings = new JsonSerializerSettings
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        PreserveReferencesHandling = PreserveReferencesHandling.Arrays,
        TypeNameHandling = TypeNameHandling.Auto,
        StringEscapeHandling = StringEscapeHandling.Default
      };
      return new ContentResult
      {
        Content = JsonConvert.SerializeObject(obj, settings),
        ContentType = "application/json"
      };
    }
  }
}