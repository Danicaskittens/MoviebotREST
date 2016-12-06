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
using api.DAL;
using api.Models.Data;
using api.Models.OutputModels;

namespace api.Controllers
{
    public class ProjectionsController : ApiController
    {
        private MovieBotContext db = new MovieBotContext();

        // GET: api/Projections
        public IQueryable<Projection> GetProjections()
        {
            return db.Projections;
        }

        // GET: api/Projections/5
        [ResponseType(typeof(Projection))]
        public IHttpActionResult GetProjection(string id)
        {
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return NotFound();
            }

            return Ok(projection);
        }

        [ResponseType(typeof(JsonApiOutput<IQueryable<ProjectionOutputModel>>))]
        public IHttpActionResult GetProjection(int cinemaid, string imdbId, DateTime date)
        {
            IQueryable<Projection> projections =
                db.Projections.Where(p => p.CinemaId == cinemaid && p.ImdbId == imdbId && p.Date.Date == date.Date);
            IQueryable<ProjectionOutputModel> projoutput = projections.Select<Projection, ProjectionOutputModel>(
                                                                p => new ProjectionOutputModel(p));
            if (projoutput == null)
            {
                return NotFound();
            }

            return Ok(projoutput);
        }

        // PUT: api/Projections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjection(int id, Projection projection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projection.ProjectionId)
            {
                return BadRequest();
            }

            db.Entry(projection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult PostProjection(Projection projection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projections.Add(projection);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProjectionExists(projection.ProjectionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = projection.ProjectionId }, projection);
        }

        // DELETE: api/Projections/5
        [ResponseType(typeof(Projection))]
        public IHttpActionResult DeleteProjection(string id)
        {
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return NotFound();
            }

            db.Projections.Remove(projection);
            db.SaveChanges();

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
            return db.Projections.Count(e => e.ProjectionId == id) > 0;
        }
    }
}