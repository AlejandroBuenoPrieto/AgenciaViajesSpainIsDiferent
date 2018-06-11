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
    public class CasaruralsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Casarurals
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userCasarurals = db.Casarurals.Where(c => c.UserId == currentUserId).ToList();
            return View(userCasarurals);
        }

        // GET: Casarurals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casarural casarural = db.Casarurals.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((casarural.UserId != currentUserId) || (casarural == null))
            {
                return HttpNotFound();
            }
            return View(casarural);
        }

        // GET: Casarurals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Casarurals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCasa,nombre,calle,provincia,numerocalle,codigopostal,descripcion,piscina,actividades")] Casarural casarural)
        {
            string currentUserId = User.Identity.GetUserId();
            casarural.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Casarurals.Add(casarural);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(casarural);
        }

        // GET: Casarurals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casarural casarural = db.Casarurals.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((casarural.UserId != currentUserId) || (casarural == null))
            {
                return HttpNotFound();
            }
            return View(casarural);
        }

        // POST: Casarurals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCasa,nombre,calle,provincia,numerocalle,codigopostal,descripcion,piscina,actividades")] Casarural casarural)
        {
            string currentUserId = User.Identity.GetUserId();
            casarural.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(casarural).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(casarural);
        }

        // GET: Casarurals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casarural casarural = db.Casarurals.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((casarural.UserId != currentUserId) || (casarural == null))
            {
                return HttpNotFound();
            }
            return View(casarural);
        }

        // POST: Casarurals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Casarural casarural = db.Casarurals.Find(id);
            db.Casarurals.Remove(casarural);
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
