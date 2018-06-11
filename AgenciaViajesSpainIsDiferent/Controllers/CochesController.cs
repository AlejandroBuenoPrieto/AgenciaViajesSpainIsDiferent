using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgenciaViajesSpainIsDiferent.Models;
using Microsoft.AspNet.Identity;

namespace AgenciaViajesSpainIsDiferent.Controllers
{
    [Authorize]
    public class CochesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Coches
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userCoches = db.Coches.Where(c => c.UserId == currentUserId).ToList();
            return View(userCoches);
        }

        // GET: Coches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coche coche = db.Coches.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((coche.UserId != currentUserId) || (coche == null))
            {
                return HttpNotFound();
            }
            return View(coche);
        }

        // GET: Coches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coches/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCoche,seguro,sillaniños,opcionsilla,compañia,calle,provincia,numerocalle,codigopostal,numerocoches")] Coche coche)
        {
            string currentUserId = User.Identity.GetUserId();
            coche.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Coches.Add(coche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coche);
        }

        // GET: Coches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coche coche = db.Coches.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((coche.UserId != currentUserId) || (coche == null))
            {
                return HttpNotFound();
            }
            return View(coche);
        }

        // POST: Coches/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCoche,seguro,sillaniños,opcionsilla,compañia,calle,provincia,numerocalle,codigopostal,numerocoches")] Coche coche)
        {
            string currentUserId = User.Identity.GetUserId();
            coche.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(coche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coche);
        }

        // GET: Coches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coche coche = db.Coches.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((coche.UserId != currentUserId) || (coche == null))
            {
                return HttpNotFound();
            }
            return View(coche);
        }

        // POST: Coches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coche coche = db.Coches.Find(id);
            db.Coches.Remove(coche);
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
