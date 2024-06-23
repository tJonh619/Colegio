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
    public class EstudiantesAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/EstudiantesAPI
        public IQueryable<Estudiante> GetEstudiantes()
        {
            return db.Estudiantes;
        }

        // GET: api/EstudiantesAPI/5
        [ResponseType(typeof(Estudiante))]
        public IHttpActionResult GetEstudiante(int id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        // PUT: api/EstudiantesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstudiante(int id, Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudiante.Id)
            {
                return BadRequest();
            }

            db.Entry(estudiante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
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

        // POST: api/EstudiantesAPI
        [ResponseType(typeof(Estudiante))]
        public IHttpActionResult PostEstudiante(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estudiantes.Add(estudiante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estudiante.Id }, estudiante);
        }

        // DELETE: api/EstudiantesAPI/5
        [ResponseType(typeof(Estudiante))]
        public IHttpActionResult DeleteEstudiante(int id)
        {
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            db.Estudiantes.Remove(estudiante);
            db.SaveChanges();

            return Ok(estudiante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudianteExists(int id)
        {
            return db.Estudiantes.Count(e => e.Id == id) > 0;
        }
    }
}