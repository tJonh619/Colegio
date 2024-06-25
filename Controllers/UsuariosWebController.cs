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
    public class UsuariosWebController : Controller
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: UsuariosWeb
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Rol).Include(u => u.Colegio);
            return View(usuarios.ToList());
        }

        // GET: UsuariosWeb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: UsuariosWeb/Create
        public ActionResult Create()
        {
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.RolId = new SelectList(db.Roles, "Id", "NombreRol");
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio");
            return View();
        }

        // POST: UsuariosWeb/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RolId,Nombres,Apellidos,NombreDeUsuario,ClaveUsuario,CorreoRecuperacion,FechaModificacion,Activo,ColegioId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.RolId = new SelectList(db.Roles, "Id", "NombreRol", usuario.RolId);
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", usuario.ColegioId);
            return View(usuario);
        }

        // GET: UsuariosWeb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.RolId = new SelectList(db.Roles, "Id", "NombreRol", usuario.RolId);
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", usuario.ColegioId);
            return View(usuario);
        }

        // POST: UsuariosWeb/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RolId,Nombres,Apellidos,NombreDeUsuario,ClaveUsuario,CorreoRecuperacion,FechaModificacion,Activo,ColegioId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var activoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Sí", Value = "true" },
                new SelectListItem { Text = "No", Value = "false" }
            };
            ViewBag.ActivoOptions = activoOptions;
            ViewBag.RolId = new SelectList(db.Roles, "Id", "NombreRol", usuario.RolId);
            ViewBag.ColegioId = new SelectList(db.Colegios, "Id", "CodigoColegio", usuario.ColegioId);
            return View(usuario);
        }

        // GET: UsuariosWeb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: UsuariosWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
