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
    public class MatriculasWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: MatriculasWeb
        public ActionResult Index()
        {
            var matriculas = db.Matriculas.Include(m => m.Tutor).Include(m => m.Estudiante).Include(m => m.Grado).Include(m => m.Periodo).Include(m => m.Colegio);
            return View(matriculas.ToList());
        }

        // GET: MatriculasWeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: MatriculasWeb/Create
        public ActionResult Create()
        {
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.TutorId = new SelectList(db.Tutores, "Id", "Nombres");
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CodigoEstudiante");
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre");
            ViewBag.PeriodoId = new SelectList(db.Periodos, "Id", "Nombre");
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio");
            return View();
        }

        // POST: MatriculasWeb/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TutorId,EstudianteId,GradoId,PeriodoId,CodigoMatricula,Descripcion,ColegioProcedencia,Repitente,Activo,FechaModificacion,ColegioId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.TutorId = new SelectList(db.Tutores, "Id", "Nombres", matricula.TutorId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CodigoEstudiante", matricula.EstudianteId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", matricula.GradoId);
            ViewBag.PeriodoId = new SelectList(db.Periodos, "Id", "Nombre", matricula.PeriodoId);
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", matricula.ColegioId);
            return View(matricula);
        }

        // GET: MatriculasWeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.TutorId = new SelectList(db.Tutores, "Id", "Nombres", matricula.TutorId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CodigoEstudiante", matricula.EstudianteId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", matricula.GradoId);
            ViewBag.PeriodoId = new SelectList(db.Periodos, "Id", "Nombre", matricula.PeriodoId);
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", matricula.ColegioId);
            return View(matricula);
        }

        // POST: MatriculasWeb/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TutorId,EstudianteId,GradoId,PeriodoId,CodigoMatricula,Descripcion,ColegioProcedencia,Repitente,Activo,FechaModificacion,ColegioId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.TutorId = new SelectList(db.Tutores, "Id", "Nombres", matricula.TutorId);
            ViewBag.EstudianteId = new SelectList(db.Estudiantes, "Id", "CodigoEstudiante", matricula.EstudianteId);
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", matricula.GradoId);
            ViewBag.PeriodoId = new SelectList(db.Periodos, "Id", "Nombre", matricula.PeriodoId);
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", matricula.ColegioId);
            return View(matricula);
        }

        // GET: MatriculasWeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: MatriculasWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            db.Matriculas.Remove(matricula);
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
