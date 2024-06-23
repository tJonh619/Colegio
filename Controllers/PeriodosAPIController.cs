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
    public class PeriodosAPIController : ApiController
    {
        private ModeloColegioContainer db = new ModeloColegioContainer();

        // GET: api/PeriodosWeb
        public IQueryable<Periodo> GetPeriodos()
        {
            return db.Periodos;
        }

        // GET: api/PeriodosWeb/5
        [ResponseType(typeof(Periodo))]
        public IHttpActionResult GetPeriodo(int id)
        {
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }

            return Ok(periodo);
        }

        // PUT: api/PeriodosWeb/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPeriodo(int id, Periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periodo.Id)
            {
                return BadRequest();
            }

            db.Entry(periodo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodoExists(id))
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

        // POST: api/PeriodosWeb
        [ResponseType(typeof(Periodo))]
        public IHttpActionResult PostPeriodo(Periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Periodos.Add(periodo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = periodo.Id }, periodo);
        }

        // DELETE: api/PeriodosWeb/5
        [ResponseType(typeof(Periodo))]
        public IHttpActionResult DeletePeriodo(int id)
        {
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return NotFound();
            }

            db.Periodos.Remove(periodo);
            db.SaveChanges();

            return Ok(periodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeriodoExists(int id)
        {
            return db.Periodos.Count(e => e.Id == id) > 0;
        }
    }
}