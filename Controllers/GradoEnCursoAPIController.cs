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
    public class GradoEnCursoAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/GradoEnCursoAPI
        public IQueryable<GradoEnCurso> GetGradosEnCursos()
        {
            return db.GradosEnCursos;
        }

        // GET: api/GradoEnCursoAPI/5
        [ResponseType(typeof(GradoEnCurso))]
        public IHttpActionResult GetGradoEnCurso(int id)
        {
            GradoEnCurso gradoEnCurso = db.GradosEnCursos.Find(id);
            if (gradoEnCurso == null)
            {
                return NotFound();
            }

            return Ok(gradoEnCurso);
        }

        // PUT: api/GradoEnCursoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGradoEnCurso(int id, GradoEnCurso gradoEnCurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gradoEnCurso.Id)
            {
                return BadRequest();
            }

            db.Entry(gradoEnCurso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoEnCursoExists(id))
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

        // POST: api/GradoEnCursoAPI
        [ResponseType(typeof(GradoEnCurso))]
        public IHttpActionResult PostGradoEnCurso(GradoEnCurso gradoEnCurso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GradosEnCursos.Add(gradoEnCurso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gradoEnCurso.Id }, gradoEnCurso);
        }

        // DELETE: api/GradoEnCursoAPI/5
        [ResponseType(typeof(GradoEnCurso))]
        public IHttpActionResult DeleteGradoEnCurso(int id)
        {
            GradoEnCurso gradoEnCurso = db.GradosEnCursos.Find(id);
            if (gradoEnCurso == null)
            {
                return NotFound();
            }

            db.GradosEnCursos.Remove(gradoEnCurso);
            db.SaveChanges();

            return Ok(gradoEnCurso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradoEnCursoExists(int id)
        {
            return db.GradosEnCursos.Count(e => e.Id == id) > 0;
        }
    }
}