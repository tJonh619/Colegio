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
    public class EstudiantesWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: EstudiantesWeb
        public ActionResult Index()
        {
            var estudiantes = db.Estudiantes.Include(e => e.Colegio);
            return View(estudiantes.ToList());
        }

        // GET: EstudiantesWeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: EstudiantesWeb/Create
        public ActionResult Create()
        {
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio");
            return View();
        }

        // POST: EstudiantesWeb/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoEstudiante,Nombres,Apellidos,Sexo,Direccion,Activo,FechaModificacion,ColegioId")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Estudiantes.Add(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", estudiante.ColegioId);
            return View(estudiante);
        }

        // GET: EstudiantesWeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", estudiante.ColegioId);
            return View(estudiante);
        }

        // POST: EstudiantesWeb/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoEstudiante,Nombres,Apellidos,Sexo,Direccion,Activo,FechaModificacion,ColegioId")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", estudiante.ColegioId);
            return View(estudiante);
        }

        // GET: EstudiantesWeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: EstudiantesWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            db.Estudiantes.Remove(estudiante);
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
