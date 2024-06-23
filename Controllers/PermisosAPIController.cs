using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiColegio.Models;

namespace ApiColegio.Controllers
{
    public class PermisosAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/PermisosAPI
        public IQueryable<Permiso> GetPermisos()
        {
            return db.Permisos;
        }

        // GET: api/PermisosAPI/5
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult GetPermiso(int id)
        {
            Permiso permiso = db.Permisos.Find(id);
            if (permiso == null)
            {
                return NotFound();
            }

            return Ok(permiso);
        }

        // PUT: api/PermisosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPermiso(int id, Permiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permiso.Id)
            {
                return BadRequest();
            }

            db.Entry(permiso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PermisosAPI
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult PostPermiso(Permiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Permisos.Add(permiso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permiso.Id }, permiso);
        }

        // DELETE: api/PermisosAPI/5
        [ResponseType(typeof(Permiso))]
        public IHttpActionResult DeletePermiso(int id)
        {
            Permiso permiso = db.Permisos.Find(id);
            if (permiso == null)
            {
                return NotFound();
            }

            db.Permisos.Remove(permiso);
            db.SaveChanges();

            return Ok(permiso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermisoExists(int id)
        {
            return db.Permisos.Count(e => e.Id == id) > 0;
        }
    }
}