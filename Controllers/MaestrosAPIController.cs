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
    public class MaestrosAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/MaestrosAPI
        public IQueryable<Maestro> GetMaestros()
        {
            return db.Maestros;
        }

        // GET: api/MaestrosAPI/5
        [ResponseType(typeof(Maestro))]
        public IHttpActionResult GetMaestro(int id)
        {
            Maestro maestro = db.Maestros.Find(id);
            if (maestro == null)
            {
                return NotFound();
            }

            return Ok(maestro);
        }

        // PUT: api/MaestrosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaestro(int id, Maestro maestro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maestro.Id)
            {
                return BadRequest();
            }

            db.Entry(maestro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestroExists(id))
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

        // POST: api/MaestrosAPI
        [ResponseType(typeof(Maestro))]
        public IHttpActionResult PostMaestro(Maestro maestro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Maestros.Add(maestro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = maestro.Id }, maestro);
        }

        // DELETE: api/MaestrosAPI/5
        [ResponseType(typeof(Maestro))]
        public IHttpActionResult DeleteMaestro(int id)
        {
            Maestro maestro = db.Maestros.Find(id);
            if (maestro == null)
            {
                return NotFound();
            }

            db.Maestros.Remove(maestro);
            db.SaveChanges();

            return Ok(maestro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaestroExists(int id)
        {
            return db.Maestros.Count(e => e.Id == id) > 0;
        }
    }
}