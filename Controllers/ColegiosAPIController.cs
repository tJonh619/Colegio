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
    public class ColegiosAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/ColegiosAPI
        public IQueryable<Colegio> GetColegios()
        {
            return db.Colegios;
        }

        // GET: api/ColegiosAPI/5
        [ResponseType(typeof(Colegio))]
        public IHttpActionResult GetColegio(int id)
        {
            Colegio colegio = db.Colegios.Find(id);
            if (colegio == null)
            {
                return NotFound();
            }

            return Ok(colegio);
        }

        // PUT: api/ColegiosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColegio(int id, Colegio colegio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colegio.Id)
            {
                return BadRequest();
            }

            db.Entry(colegio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColegioExists(id))
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

        // POST: api/ColegiosAPI
        [ResponseType(typeof(Colegio))]
        public IHttpActionResult PostColegio(Colegio colegio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Colegios.Add(colegio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = colegio.Id }, colegio);
        }

        // DELETE: api/ColegiosAPI/5
        [ResponseType(typeof(Colegio))]
        public IHttpActionResult DeleteColegio(int id)
        {
            Colegio colegio = db.Colegios.Find(id);
            if (colegio == null)
            {
                return NotFound();
            }

            db.Colegios.Remove(colegio);
            db.SaveChanges();

            return Ok(colegio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColegioExists(int id)
        {
            return db.Colegios.Count(e => e.Id == id) > 0;
        }
    }
}