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
    public class MaestrosWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: MaestrosWeb
        public ActionResult Index()
        {
            var maestros = db.Maestros.Include(m => m.Colegio);
            return View(maestros.ToList());
        }

        // GET: MaestrosWeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro maestro = db.Maestros.Find(id);
            if (maestro == null)
            {
                return HttpNotFound();
            }
            return View(maestro);
        }

        // GET: MaestrosWeb/Create
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

        // POST: MaestrosWeb/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoMaestro,Cedula,Nombres,Apellidos,Sexo,Direccion,Correo,Celular,Activo,FechaModificacion,ColegioId")] Maestro maestro)
        {
            if (ModelState.IsValid)
            {
                db.Maestros.Add(maestro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", maestro.ColegioId);
            return View(maestro);
        }

        // GET: MaestrosWeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro maestro = db.Maestros.Find(id);
            if (maestro == null)
            {
                return HttpNotFound();
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", maestro.ColegioId);
            return View(maestro);
        }

        // POST: MaestrosWeb/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoMaestro,Cedula,Nombres,Apellidos,Sexo,Direccion,Correo,Celular,Activo,FechaModificacion,ColegioId")] Maestro maestro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maestro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", maestro.ColegioId);
            return View(maestro);
        }

        // GET: MaestrosWeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro maestro = db.Maestros.Find(id);
            if (maestro == null)
            {
                return HttpNotFound();
            }
            return View(maestro);
        }

        // POST: MaestrosWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maestro maestro = db.Maestros.Find(id);
            db.Maestros.Remove(maestro);
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
