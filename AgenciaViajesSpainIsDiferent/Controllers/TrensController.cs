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
    public class TrensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trens
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userTrens = db.Trens.Where(c => c.UserId == currentUserId).ToList();
            return View(userTrens);
        }

        // GET: Trens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tren tren = db.Trens.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((tren.UserId != currentUserId) || (tren == null))
            {
                return HttpNotFound();
            }
            return View(tren);
        }

        // GET: Trens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trenid,cantidad,precio,tipo,cafeteria,compania,origen,destino,numeroplazas")] Tren tren)
        {
            string currentUserId = User.Identity.GetUserId();
            tren.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Trens.Add(tren);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tren);
        }

        // GET: Trens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tren tren = db.Trens.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((tren.UserId != currentUserId) || (tren == null))
            {
                return HttpNotFound();
            }
            return View(tren);
        }

        // POST: Trens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trenid,cantidad,precio,tipo,cafeteria,compania,origen,destino,numeroplazas")] Tren tren)
        {
            string currentUserId = User.Identity.GetUserId();
            tren.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(tren).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tren);
        }

        // GET: Trens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tren tren = db.Trens.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((tren.UserId != currentUserId) || (tren == null))
            {
                return HttpNotFound();
            }
            return View(tren);
        }

        // POST: Trens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tren tren = db.Trens.Find(id);
            db.Trens.Remove(tren);
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
