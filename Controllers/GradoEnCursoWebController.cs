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
    public class GradoEnCursoWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: GradoEnCursoWeb
        public ActionResult Index()
        {
            var gradosEnCursos = db.GradosEnCursos.Include(g => g.Grado).Include(g => g.Maestro).Include(g => g.Seccion);
            return View(gradosEnCursos.ToList());
        }

        // GET: GradoEnCursoWeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradoEnCurso gradoEnCurso = db.GradosEnCursos.Find(id);
            if (gradoEnCurso == null)
            {
                return HttpNotFound();
            }
            return View(gradoEnCurso);
        }

        // GET: GradoEnCursoWeb/Create
        public ActionResult Create()
        {
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre");
            ViewBag.MaestroId = new SelectList(db.Maestros, "Id", "CodigoMaestro");
            ViewBag.SeccionId = new SelectList(db.Secciones, "Id", "Nombre");
            return View();
        }

        // POST: GradoEnCursoWeb/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GradoId,MaestroId,SeccionId,Año,Activo")] GradoEnCurso gradoEnCurso)
        {
            if (ModelState.IsValid)
            {
                db.GradosEnCursos.Add(gradoEnCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", gradoEnCurso.GradoId);
            ViewBag.MaestroId = new SelectList(db.Maestros, "Id", "CodigoMaestro", gradoEnCurso.MaestroId);
            ViewBag.SeccionId = new SelectList(db.Secciones, "Id", "Nombre", gradoEnCurso.SeccionId);
            return View(gradoEnCurso);
        }

        // GET: GradoEnCursoWeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradoEnCurso gradoEnCurso = db.GradosEnCursos.Find(id);
            if (gradoEnCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", gradoEnCurso.GradoId);
            ViewBag.MaestroId = new SelectList(db.Maestros, "Id", "CodigoMaestro", gradoEnCurso.MaestroId);
            ViewBag.SeccionId = new SelectList(db.Secciones, "Id", "Nombre", gradoEnCurso.SeccionId);
            return View(gradoEnCurso);
        }

        // POST: GradoEnCursoWeb/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GradoId,MaestroId,SeccionId,Año,Activo")] GradoEnCurso gradoEnCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradoEnCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GradoId = new SelectList(db.Grados, "Id", "Nombre", gradoEnCurso.GradoId);
            ViewBag.MaestroId = new SelectList(db.Maestros, "Id", "CodigoMaestro", gradoEnCurso.MaestroId);
            ViewBag.SeccionId = new SelectList(db.Secciones, "Id", "Nombre", gradoEnCurso.SeccionId);
            return View(gradoEnCurso);
        }

        // GET: GradoEnCursoWeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradoEnCurso gradoEnCurso = db.GradosEnCursos.Find(id);
            if (gradoEnCurso == null)
            {
                return HttpNotFound();
            }
            return View(gradoEnCurso);
        }

        // POST: GradoEnCursoWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradoEnCurso gradoEnCurso = db.GradosEnCursos.Find(id);
            db.GradosEnCursos.Remove(gradoEnCurso);
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
