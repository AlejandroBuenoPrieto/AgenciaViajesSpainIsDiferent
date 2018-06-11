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
    public class VueloesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vueloes
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userVueloes = db.Vueloes.Where(c => c.UserId == currentUserId).ToList();
            return View(userVueloes);
        }

        // GET: Vueloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelo vuelo = db.Vueloes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((vuelo.UserId != currentUserId) || (vuelo == null))
            {
                return HttpNotFound();
            }
            return View(vuelo);
        }

        // GET: Vueloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vueloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVuelo,lowcost,compañia,origen,destino,numeroplazas")] Vuelo vuelo)
        {
            string currentUserId = User.Identity.GetUserId();
            vuelo.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Vueloes.Add(vuelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vuelo);
        }

        // GET: Vueloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelo vuelo = db.Vueloes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((vuelo.UserId != currentUserId) || (vuelo == null))
            {
                return HttpNotFound();
            }
            return View(vuelo);
        }

        // POST: Vueloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVuelo,lowcost,compañia,origen,destino,numeroplazas")] Vuelo vuelo)
        {
            string currentUserId = User.Identity.GetUserId();
            vuelo.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(vuelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vuelo);
        }

        // GET: Vueloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelo vuelo = db.Vueloes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if ((vuelo.UserId != currentUserId) || (vuelo == null))
            {
                return HttpNotFound();
            }
            return View(vuelo);
        }

        // POST: Vueloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
            db.Vueloes.Remove(vuelo);
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
