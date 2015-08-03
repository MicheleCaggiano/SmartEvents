using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TangOrganizer.Model.Models;
using TangOrganizer.Service;

namespace TangOrganizer.Dashboard.Controllers.Attività
{
  public partial class AttivitaController : Controller
  {
    private readonly AttivitaService _attivitaService;

    public AttivitaController(AttivitaService attivitaService)
    {
      _attivitaService = attivitaService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Attivita attivita)
    {
      if (!ModelState.IsValid) return View(attivita);

      _attivitaService.Save(attivita, User.Identity.Name, User.Identity.GetUserId());
      return RedirectToAction("Edit", "Evento", new { id = attivita.EventoId });
    }

    //// GET: /Attivita/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var attivita = _attivitaService.FindById(id);
      if (attivita == null)
      {
        return HttpNotFound();
      }
      return View(attivita);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Attivita attivita)
    {
      if (!ModelState.IsValid) return View(attivita);

      _attivitaService.Update(attivita);
      return RedirectToAction("Edit", "Evento", new { id = attivita.EventoId });
    }

    //// GET: /Attivita/Delete/5
    //public ActionResult Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    var attivita = _attivitaService.FindById(id);
    //    if (attivita == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return System.Web.UI.WebControls.View(attivita);
    //}

    //// POST: /Attivita/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public ActionResult DeleteConfirmed(int id)
    //{
    //     _attivitaService.DeleteById(id);
    //    return RedirectToAction("Index");
    //}
  }
}
