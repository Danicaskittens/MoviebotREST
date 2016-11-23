using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using api.Models;

namespace api.Controllers
{
    public class ProjectionsController : ApiController
    {
        private ReservationContext db = new ReservationContext();

        // GET: api/Projections
        public IQueryable<Projection> GetProjections()
        {
            return db.Projections;
        }

        // GET: api/Projections/5
        [ResponseType(typeof(Projection))]
        public async Task<IHttpActionResult> GetProjection(int id)
        {
            Projection projection = await db.Projections.FindAsync(id);
            if (projection == null)
            {
                return NotFound();
            }

            return Ok(projection);
        }

        // PUT: api/Projections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProjection(int id, Projection projection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projection.Id)
            {
                return BadRequest();
            }

            db.Entry(projection).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectionExists(id))
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

        // POST: api/Projections
        [ResponseType(typeof(Projection))]
        public async Task<IHttpActionResult> PostProjection(Projection projection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projections.Add(projection);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = projection.Id }, projection);
        }

        // DELETE: api/Projections/5
        [ResponseType(typeof(Projection))]
        public async Task<IHttpActionResult> DeleteProjection(int id)
        {
            Projection projection = await db.Projections.FindAsync(id);
            if (projection == null)
            {
                return NotFound();
            }

            db.Projections.Remove(projection);
            await db.SaveChangesAsync();

            return Ok(projection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectionExists(int id)
        {
            return db.Projections.Count(e => e.Id == id) > 0;
        }
    }
}