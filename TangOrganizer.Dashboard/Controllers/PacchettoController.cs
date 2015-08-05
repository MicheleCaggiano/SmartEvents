using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TangOrganizer.Model.Models;

namespace TangOrganizer.Dashboard.Controllers
{
    public class PacchettoController : Controller
    {
        private readonly PacchettoesService _pacchettoesService;
     
        public PacchettoController(PacchettoesService pacchettoesService)
        {
          _pacchettoesService = pacchettoesService;
        }


        // GET: /Pacchetto/
        public ActionResult Index()
        {
            return View(_pacchettoesService.FindAll().ToList());
        }

        // GET: /Pacchetto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pacchetto = _pacchettoesService.FindById(id);
            if (pacchetto == null)
            {
                return HttpNotFound();
            }
            return View(pacchetto);
        }

        // GET: /Pacchetto/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Eventoes, "Id", "Nome");
            return View();
        }

        // POST: /Pacchetto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pacchetto pacchetto)
        {
            if (!ModelState.IsValid) return View(pacchetto);
            
            _pacchettoesService.Save(pacchetto);        
             return RedirectToAction("Index");
            ViewBag.EventoId = new SelectList(db.Eventoes, "Id", "Nome", pacchetto.EventoId);
        }

        // GET: /Pacchetto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var pacchetto = _pacchettoesService.FindById(id);
            if (pacchetto == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Eventoes, "Id", "Nome", pacchetto.EventoId);
            return View(pacchetto);
        }

        // POST: /Pacchetto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pacchetto pacchetto)
        {
            if (!ModelState.IsValid) return View(pacchetto);
                            
            _pacchettoesService.Update(pacchetto);        
            return RedirectToAction("Index");                    
            ViewBag.EventoId = new SelectList(db.Eventoes, "Id", "Nome", pacchetto.EventoId);
        }

        // GET: /Pacchetto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pacchetto = _pacchettoesService.FindById(id);
            if (pacchetto == null)
            {
                return HttpNotFound();
            }
            return View(pacchetto);
        }

        // POST: /Pacchetto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             _pacchettoesService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
