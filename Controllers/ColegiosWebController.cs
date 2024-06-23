using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiColegio.Models;

namespace ApiColegio.Controllers
{
    public class ColegiosWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: ColegiosWeb
        public ActionResult Index()
        {
            return View(db.Colegios.ToList());
        }

        // GET: ColegiosWeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colegio colegio = db.Colegios.Find(id);
            if (colegio == null)
            {
                return HttpNotFound();
            }
            return View(colegio);
        }

        // GET: ColegiosWeb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColegiosWeb/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoColegio,Nombre,Direccion,Telefono,Correo,Activo,FechaModificacion")] Colegio colegio)
        {
            if (ModelState.IsValid)
            {
                db.Colegios.Add(colegio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colegio);
        }

        // GET: ColegiosWeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colegio colegio = db.Colegios.Find(id);
            if (colegio == null)
            {
                return HttpNotFound();
            }
            return View(colegio);
        }

        // POST: ColegiosWeb/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoColegio,Nombre,Direccion,Telefono,Correo,Activo,FechaModificacion")] Colegio colegio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colegio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colegio);
        }

        // GET: ColegiosWeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colegio colegio = db.Colegios.Find(id);
            if (colegio == null)
            {
                return HttpNotFound();
            }
            return View(colegio);
        }

        // POST: ColegiosWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colegio colegio = db.Colegios.Find(id);
            db.Colegios.Remove(colegio);
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
