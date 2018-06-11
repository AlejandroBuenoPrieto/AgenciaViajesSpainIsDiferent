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
    public class CruceroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cruceroes
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userCruceroes = db.Cruceroes.Where(c => c.UserId == currentUserId).ToList();
            return View(userCruceroes);
        }

        // GET: Cruceroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crucero crucero = db.Cruceroes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((crucero.UserId != currentUserId) || (crucero == null))
            {
                return HttpNotFound();
            }
            return View(crucero);
        }

        // GET: Cruceroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cruceroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCrucero,tipobarco,compañia,origen,destino,numeroplazas,descripcion,duracion")] Crucero crucero)
        {
            string currentUserId = User.Identity.GetUserId();
            crucero.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Cruceroes.Add(crucero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crucero);
        }

        // GET: Cruceroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crucero crucero = db.Cruceroes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((crucero.UserId != currentUserId) || (crucero == null))
            {
                return HttpNotFound();
            }
            return View(crucero);
        }

        // POST: Cruceroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCrucero,tipobarco,compañia,origen,destino,numeroplazas,descripcion,duracion")] Crucero crucero)
        {
            string currentUserId = User.Identity.GetUserId();
            crucero.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(crucero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crucero);
        }

        // GET: Cruceroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crucero crucero = db.Cruceroes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((crucero.UserId != currentUserId) || (crucero == null))
            {
                return HttpNotFound();
            }
            return View(crucero);
        }

        // POST: Cruceroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crucero crucero = db.Cruceroes.Find(id);
            db.Cruceroes.Remove(crucero);
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
