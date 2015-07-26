using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using SmartEvents.BLL;
using SmartEvents.Model.Models;

namespace SmartEvents.Dashboard.Controllers
{
  public class EventoController : Controller
  {
    private readonly EventoService _eventoService;

    public EventoController(EventoService eventoService)
    {
      _eventoService = eventoService;
    }

    // GET: /Evento/
    public ActionResult Index()
    {
      return View(_eventoService.GetEvents(0, 10));
    }

    // GET: /Evento/Details/5
    public ActionResult Details(Guid? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var evento = _eventoService.FindById(id);
      if (evento == null)
      {
        return HttpNotFound();
      }
      return View(evento);
    }

    // GET: /Evento/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: /Evento/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Evento evento)
    {
      if (!ModelState.IsValid) return View(evento);

      _eventoService.Save(evento, User.Identity.Name, User.Identity.GetUserId());
      return RedirectToAction("Edit", new { id = evento.Id });
    }

    // GET: /Evento/Edit/5
    public ActionResult Edit(Guid? id)
    {
      if (id == null || id == Guid.Empty)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var evento = _eventoService.FindById(id);
      if (evento == null)
      {
        return HttpNotFound();
      }
      return View(evento);
    }

    // POST: /Evento/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Evento evento)
    {
      if (!ModelState.IsValid) return View(evento);

      _eventoService.Update(evento);
      return RedirectToAction("Index");
    }

    // GET: /Evento/DeleteById/5
    public ActionResult Delete(Guid? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var evento = _eventoService.FindById(id);
      if (evento == null)
      {
        return HttpNotFound();
      }
      return View(evento);
    }

    [HttpPost]
    public string SetEventImages()
    {
      var httpRequest = System.Web.HttpContext.Current.Request;
      string eventId;
      try
      {
        eventId = System.Web.HttpContext.Current.Request.Params["EventId"];
      }
      catch (Exception)
      {
        return "Superato il limite di 50Mb per Upload";
      }
      var findedPath = ConfigurationManager.AppSettings["EventsRoot"];

      if (httpRequest.Files.Count > 0)
      {
        foreach (string file in httpRequest.Files)
        {
          var postedFile = httpRequest.Files[file];
          var filePath = string.Empty;
          try
          {
            // Creates event folder path
            filePath = string.Format("{0}{1}{2}", System.Web.HttpContext.Current.Server.MapPath("~/"), findedPath, eventId);

            // Creates folder hierarchy: productIdFolder/ -> large-medium-small
            if (!Directory.Exists(filePath))
            {
              CreatesFolderHierarchy(filePath);
            }
            //// Save large image
            //postedFile.SaveAs(filePath + "\\large\\" + postedFile.FileName);
            //Image image = new Image(filePath + "\\large\\", postedFile.FileName);
            //// Save medium image
            //var imageThumb = image.CreateThumbnail(360, 480);
            //image.SaveImage(imageThumb, filePath + "\\medium\\", postedFile.FileName, deleteIfExists: true);

            //postedFile.SaveAs(filePath + "\\" + postedFile.FileName);
          }
          catch (Exception)
          {
            return "Percorso non trovato: " + filePath;
          }
        }
        //return Request.CreateResponse(HttpStatusCode.Created, docfiles);
      }
      else
      {
        //result = Request.CreateResponse(HttpStatusCode.BadRequest);
        return "Errore: 0 immagini inviate";
      }
      return "Immagine caricata";
    }

    // POST: /Evento/DeleteById/5
    [HttpPost, ActionName("DeleteById")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Guid id)
    {
      _eventoService.DeleteById(id);
      return RedirectToAction("Index");
    }


    /// <summary>
    /// Creates event folder hierarchy
    /// </summary>
    /// <param name="filePath">Events root path</param>
    private void CreatesFolderHierarchy(string filePath)
    {
      // Creates event root folder
      Directory.CreateDirectory(filePath);
      // Creates root subfolders
      Directory.CreateDirectory(filePath + "\\large");
      Directory.CreateDirectory(filePath + "\\medium");
    }
  }
}
