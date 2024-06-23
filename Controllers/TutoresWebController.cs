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
    public class TutoresWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: TutoresWeb
        public ActionResult Index()
        {
            return View(db.Tutores.ToList());
        }

        // GET: TutoresWeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutores.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // GET: TutoresWeb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TutoresWeb/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombres,Apellidos,RelacionConElEstudiante,Cedula,Direccion,Celular,FechaModificacion,Activo")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Tutores.Add(tutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tutor);
        }

        // GET: TutoresWeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutores.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: TutoresWeb/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombres,Apellidos,RelacionConElEstudiante,Cedula,Direccion,Celular,FechaModificacion,Activo")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutor);
        }

        // GET: TutoresWeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutores.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: TutoresWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutor tutor = db.Tutores.Find(id);
            db.Tutores.Remove(tutor);
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
