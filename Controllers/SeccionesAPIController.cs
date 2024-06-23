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
    public class SeccionesAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/SeccionesAPI
        public IQueryable<Seccion> GetSecciones()
        {
            return db.Secciones;
        }

        // GET: api/SeccionesAPI/5
        [ResponseType(typeof(Seccion))]
        public IHttpActionResult GetSeccion(int id)
        {
            Seccion seccion = db.Secciones.Find(id);
            if (seccion == null)
            {
                return NotFound();
            }

            return Ok(seccion);
        }

        // PUT: api/SeccionesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeccion(int id, Seccion seccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seccion.Id)
            {
                return BadRequest();
            }

            db.Entry(seccion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeccionExists(id))
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

        // POST: api/SeccionesAPI
        [ResponseType(typeof(Seccion))]
        public IHttpActionResult PostSeccion(Seccion seccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Secciones.Add(seccion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = seccion.Id }, seccion);
        }

        // DELETE: api/SeccionesAPI/5
        [ResponseType(typeof(Seccion))]
        public IHttpActionResult DeleteSeccion(int id)
        {
            Seccion seccion = db.Secciones.Find(id);
            if (seccion == null)
            {
                return NotFound();
            }

            db.Secciones.Remove(seccion);
            db.SaveChanges();

            return Ok(seccion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeccionExists(int id)
        {
            return db.Secciones.Count(e => e.Id == id) > 0;
        }
    }
}