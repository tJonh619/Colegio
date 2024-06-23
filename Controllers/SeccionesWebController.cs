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
    public class SeccionesWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: SeccionesWeb
        public ActionResult Index()
        {
            var secciones = db.Secciones.Include(s => s.Colegio);
            return View(secciones.ToList());
        }

        // GET: SeccionesWeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = db.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // GET: SeccionesWeb/Create
        public ActionResult Create()
        {
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio");
            return View();
        }

        // POST: SeccionesWeb/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,CapacidadEstudiantes,Activo,ColegioId")] Seccion seccion)
        {
            if (ModelState.IsValid)
            {
                db.Secciones.Add(seccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", seccion.ColegioId);
            return View(seccion);
        }

        // GET: SeccionesWeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = db.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", seccion.ColegioId);
            return View(seccion);
        }

        // POST: SeccionesWeb/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,CapacidadEstudiantes,Activo,ColegioId")] Seccion seccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", seccion.ColegioId);
            return View(seccion);
        }

        // GET: SeccionesWeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = db.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // POST: SeccionesWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seccion seccion = db.Secciones.Find(id);
            db.Secciones.Remove(seccion);
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
