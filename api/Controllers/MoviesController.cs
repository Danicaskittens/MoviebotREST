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
using api.Adapters;

namespace api.Controllers
{
    public class MoviesController : ApiController
    {
        private MovieBotContext db = new MovieBotContext();

        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(string id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(string id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.ImdbId)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(String imdbId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Movie movie = OmdbAdapters.GetMovieInfo(imdbId);
            db.Movies.Add(movie);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MovieExists(movie.ImdbId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = movie.ImdbId }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(string id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(string id)
        {
            return db.Movies.Count(e => e.ImdbId == id) > 0;
        }
    }
}