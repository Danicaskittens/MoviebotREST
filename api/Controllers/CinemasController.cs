﻿using System;
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
        private CinemaInterfaceServerModelContainer db = new CinemaInterfaceServerModelContainer();

        // GET: api/Cinemas
        public IQueryable<Cinema> GetCinemas()
        {
            return db.CinemaSet;
        }

        // GET: api/Cinemas/5
        [ResponseType(typeof(Cinema))]
        public IHttpActionResult GetCinema(string id)
        {
            Cinema cinema = db.CinemaSet.Find(id);
            if (cinema == null)
            {
                return NotFound();
            }

            return Ok(cinema);
        }

        // PUT: api/Cinemas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCinema(int id, Cinema cinema)
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

            db.CinemaSet.Add(cinema);

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
            Cinema cinema = db.CinemaSet.Find(id);
            if (cinema == null)
            {
                return NotFound();
            }

            db.CinemaSet.Remove(cinema);
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

        private bool CinemaExists(int id)
        {
            return db.CinemaSet.Count(e => e.CinemaId == id) > 0;
        }
    }
}