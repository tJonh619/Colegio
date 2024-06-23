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
    public class CalificacionesWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: Calificaciones
        public ActionResult Index()
        {
            var calificaciones = db.Calificaciones.Include(c => c.Materia).Include(c => c.Estudiante);
            return View(calificaciones.ToList());
        }

        // GET: Calificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificaciones.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // GET: Calificaciones/Create
        public ActionResult Create()
        {
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "Nombre");
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CodigoEstudiante");
            return View();
        }

        // POST: Calificaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MateriaId,EstudianteId,NotaCualitativa,NotaNumerica,Activo")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Calificaciones.Add(calificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "Nombre", calificacion.MateriaId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CodigoEstudiante", calificacion.EstudianteId);
            return View(calificacion);
        }

        // GET: Calificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificaciones.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "Nombre", calificacion.MateriaId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CodigoEstudiante", calificacion.EstudianteId);
            return View(calificacion);
        }

        // POST: Calificaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MateriaId,EstudianteId,NotaCualitativa,NotaNumerica,Activo")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MateriaId = new SelectList(db.Materias, "Id", "Nombre", calificacion.MateriaId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CodigoEstudiante", calificacion.EstudianteId);
            return View(calificacion);
        }

        // GET: Calificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificaciones.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificacion calificacion = db.Calificaciones.Find(id);
            db.Calificaciones.Remove(calificacion);
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
