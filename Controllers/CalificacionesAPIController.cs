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
    public class CalificacionesAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/CalificacionesAPI
        public IQueryable<Calificacion> GetCalificaciones()
        {
            return db.Calificaciones;
        }

        // GET: api/CalificacionesAPI/5
        [ResponseType(typeof(Calificacion))]
        public IHttpActionResult GetCalificacion(int id)
        {
            Calificacion calificacion = db.Calificaciones.Find(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return Ok(calificacion);
        }

        // PUT: api/CalificacionesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalificacion(int id, Calificacion calificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calificacion.Id)
            {
                return BadRequest();
            }

            db.Entry(calificacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(id))
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

        // POST: api/CalificacionesAPI
        [ResponseType(typeof(Calificacion))]
        public IHttpActionResult PostCalificacion(Calificacion calificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calificaciones.Add(calificacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calificacion.Id }, calificacion);
        }

        // DELETE: api/CalificacionesAPI/5
        [ResponseType(typeof(Calificacion))]
        public IHttpActionResult DeleteCalificacion(int id)
        {
            Calificacion calificacion = db.Calificaciones.Find(id);
            if (calificacion == null)
            {
                return NotFound();
            }

            db.Calificaciones.Remove(calificacion);
            db.SaveChanges();

            return Ok(calificacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalificacionExists(int id)
        {
            return db.Calificaciones.Count(e => e.Id == id) > 0;
        }
    }
}