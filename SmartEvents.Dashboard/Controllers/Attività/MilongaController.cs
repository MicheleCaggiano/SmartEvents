using System;
using System.Web.Mvc;
using TangOrganizer.Model.Models;
using TipoAttivita = TangOrganizer.Model.Models.Enums.TipoAttivita;

namespace TangOrganizer.Dashboard.Controllers.Attività
{
  public partial class AttivitaController : Controller
  {
    public ActionResult CreateMilonga(Guid eventoId)
    {
      var attivita = new Attivita { Tipo = (int)TipoAttivita.Milonga, EventoId = eventoId };
      return View(attivita);
    }
  }
}
