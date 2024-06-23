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
    public class MatriculasAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/MatriculasAPI
        public IQueryable<Matricula> GetMatriculas()
        {
            return db.Matriculas;
        }

        // GET: api/MatriculasAPI/5
        [ResponseType(typeof(Matricula))]
        public IHttpActionResult GetMatricula(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return NotFound();
            }

            return Ok(matricula);
        }

        // PUT: api/MatriculasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatricula(int id, Matricula matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matricula.Id)
            {
                return BadRequest();
            }

            db.Entry(matricula).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriculaExists(id))
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

        // POST: api/MatriculasAPI
        [ResponseType(typeof(Matricula))]
        public IHttpActionResult PostMatricula(Matricula matricula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matriculas.Add(matricula);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = matricula.Id }, matricula);
        }

        // DELETE: api/MatriculasAPI/5
        [ResponseType(typeof(Matricula))]
        public IHttpActionResult DeleteMatricula(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return NotFound();
            }

            db.Matriculas.Remove(matricula);
            db.SaveChanges();

            return Ok(matricula);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatriculaExists(int id)
        {
            return db.Matriculas.Count(e => e.Id == id) > 0;
        }
    }
}