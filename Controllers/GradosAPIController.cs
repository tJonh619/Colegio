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
    public class GradosAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/GradosAPI
        public IQueryable<Grado> GetGrados()
        {
            return db.Grados;
        }

        // GET: api/GradosAPI/5
        [ResponseType(typeof(Grado))]
        public IHttpActionResult GetGrado(int id)
        {
            Grado grado = db.Grados.Find(id);
            if (grado == null)
            {
                return NotFound();
            }

            return Ok(grado);
        }

        // PUT: api/GradosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrado(int id, Grado grado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grado.Id)
            {
                return BadRequest();
            }

            db.Entry(grado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoExists(id))
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

        // POST: api/GradosAPI
        [ResponseType(typeof(Grado))]
        public IHttpActionResult PostGrado(Grado grado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grados.Add(grado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grado.Id }, grado);
        }

        // DELETE: api/GradosAPI/5
        [ResponseType(typeof(Grado))]
        public IHttpActionResult DeleteGrado(int id)
        {
            Grado grado = db.Grados.Find(id);
            if (grado == null)
            {
                return NotFound();
            }

            db.Grados.Remove(grado);
            db.SaveChanges();

            return Ok(grado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradoExists(int id)
        {
            return db.Grados.Count(e => e.Id == id) > 0;
        }
    }
}