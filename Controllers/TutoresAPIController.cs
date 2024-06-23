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
    public class TutoresAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/TutoresAPI
        public IQueryable<Tutor> GetTutores()
        {
            return db.Tutores;
        }

        // GET: api/TutoresAPI/5
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult GetTutor(int id)
        {
            Tutor tutor = db.Tutores.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/TutoresAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTutor(int id, Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.Id)
            {
                return BadRequest();
            }

            db.Entry(tutor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
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

        // POST: api/TutoresAPI
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult PostTutor(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tutores.Add(tutor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tutor.Id }, tutor);
        }

        // DELETE: api/TutoresAPI/5
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult DeleteTutor(int id)
        {
            Tutor tutor = db.Tutores.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            db.Tutores.Remove(tutor);
            db.SaveChanges();

            return Ok(tutor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorExists(int id)
        {
            return db.Tutores.Count(e => e.Id == id) > 0;
        }
    }
}