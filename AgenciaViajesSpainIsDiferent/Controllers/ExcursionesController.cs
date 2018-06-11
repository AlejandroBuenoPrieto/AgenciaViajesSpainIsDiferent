using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgenciaViajesSpainIsDiferent.Models;

namespace AgenciaViajesSpainIsDiferent.Controllers
{
    public class ExcursionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Excursiones
        public ActionResult Index()
        {
            return View(db.Excursiones.ToList());
        }

        // GET: Excursiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excursiones excursiones = db.Excursiones.Find(id);
            if (excursiones == null)
            {
                return HttpNotFound();
            }
            return View(excursiones);
        }

        // GET: Excursiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Excursiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExcursionId,nombreExcursion,ciudad,tipo")] Excursiones excursiones)
        {
            if (ModelState.IsValid)
            {
                db.Excursiones.Add(excursiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excursiones);
        }

        // GET: Excursiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excursiones excursiones = db.Excursiones.Find(id);
            if (excursiones == null)
            {
                return HttpNotFound();
            }
            return View(excursiones);
        }

        // POST: Excursiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExcursionId,nombreExcursion,ciudad,tipo")] Excursiones excursiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excursiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excursiones);
        }

        // GET: Excursiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excursiones excursiones = db.Excursiones.Find(id);
            if (excursiones == null)
            {
                return HttpNotFound();
            }
            return View(excursiones);
        }

        // POST: Excursiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Excursiones excursiones = db.Excursiones.Find(id);
            db.Excursiones.Remove(excursiones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
