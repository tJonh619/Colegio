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
    public class MateriasAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/MateriasAPI
        public IQueryable<Materia> GetMaterias()
        {
            return db.Materias;
        }

        // GET: api/MateriasAPI/5
        [ResponseType(typeof(Materia))]
        public IHttpActionResult GetMateria(int id)
        {
            Materia materia = db.Materias.Find(id);
            if (materia == null)
            {
                return NotFound();
            }

            return Ok(materia);
        }

        // PUT: api/MateriasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMateria(int id, Materia materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materia.Id)
            {
                return BadRequest();
            }

            db.Entry(materia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
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

        // POST: api/MateriasAPI
        [ResponseType(typeof(Materia))]
        public IHttpActionResult PostMateria(Materia materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materias.Add(materia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materia.Id }, materia);
        }

        // DELETE: api/MateriasAPI/5
        [ResponseType(typeof(Materia))]
        public IHttpActionResult DeleteMateria(int id)
        {
            Materia materia = db.Materias.Find(id);
            if (materia == null)
            {
                return NotFound();
            }

            db.Materias.Remove(materia);
            db.SaveChanges();

            return Ok(materia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MateriaExists(int id)
        {
            return db.Materias.Count(e => e.Id == id) > 0;
        }
    }
}