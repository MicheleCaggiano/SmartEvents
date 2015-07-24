using System.Web.Mvc;
using SmartEvents.BLL;

namespace SmartEvents.Dashboard.Controllers
{
  public class EventController : Controller
  {
    private readonly EventService _eventService;

    public EventController(EventService eventService)
    {
      _eventService = eventService;
    }
    public ActionResult Index()
    {
      ViewData["SubTitle"] = "Welcome in ASP.NET MVC 5 INSPINIA SeedProject ";
      ViewData["Message"] = "It is an application skeleton for a typical MVC 5 project. You can use it to quickly bootstrap your webapp projects.";

      var events = _eventService.GetEvents(0, 10);
      return View(events);
    }

    public ActionResult Minor()
    {
      ViewData["SubTitle"] = "Simple example of second view";
      ViewData["Message"] = "Data are passing to view by ViewData from controller";

      return View();
    }
  }
}