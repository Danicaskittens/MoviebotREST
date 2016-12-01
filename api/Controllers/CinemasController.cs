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

namespace api.Controllers
{
    public class CinemasController : ApiController
    {
        private MovieBotContext db = new MovieBotContext();

        // GET: api/Cinemas
        public IQueryable<Cinema> GetCinemas()
        {
            return db.Cinemas;
        }

        // GET: api/Cinemas/5
        [ResponseType(typeof(Cinema))]
        public IHttpActionResult GetCinema(string id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return NotFound();
            }

            return Ok(cinema);
        }

        // PUT: api/Cinemas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCinema(string id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cinema.CinemaId)
            {
                return BadRequest();
            }

            db.Entry(cinema).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemaExists(id))
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

        // POST: api/Cinemas
        [ResponseType(typeof(Cinema))]
        public IHttpActionResult PostCinema(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cinemas.Add(cinema);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CinemaExists(cinema.CinemaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cinema.CinemaId }, cinema);
        }

        // DELETE: api/Cinemas/5
        [ResponseType(typeof(Cinema))]
        public IHttpActionResult DeleteCinema(string id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return NotFound();
            }

            db.Cinemas.Remove(cinema);
            db.SaveChanges();

            return Ok(cinema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CinemaExists(string id)
        {
            return db.Cinemas.Count(e => e.CinemaId == id) > 0;
        }
    }
}