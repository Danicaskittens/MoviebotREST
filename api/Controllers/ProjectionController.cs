using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using api.DAL;
using api.Models.Data;

namespace api.Controllers
{
    public class ProjectionController : Controller
    {
        private MovieBotContext db = new MovieBotContext();

        // GET: Projection
        public ActionResult Index()
        {
            var projections = db.Projections.Include(p => p.Cinema).Include(p => p.Movie);
            return View(projections.ToList());
        }

        // GET: Projection/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            return View(projection);
        }

        // GET: Projection/Create
        public ActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "Name");
            ViewBag.ImdbId = new SelectList(db.Movies, "ImdbId", "Title");
            return View();
        }

        // POST: Projection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectionId,CinemaId,ImdbId,Date,FreeSeats")] Projection projection)
        {
            if (ModelState.IsValid)
            {
                db.Projections.Add(projection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "Name", projection.CinemaId);
            ViewBag.ImdbId = new SelectList(db.Movies, "ImdbId", "Title", projection.ImdbId);
            return View(projection);
        }

        // GET: Projection/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "Name", projection.CinemaId);
            ViewBag.ImdbId = new SelectList(db.Movies, "ImdbId", "Title", projection.ImdbId);
            return View(projection);
        }

        // POST: Projection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectionId,CinemaId,ImdbId,Date,FreeSeats")] Projection projection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "Name", projection.CinemaId);
            ViewBag.ImdbId = new SelectList(db.Movies, "ImdbId", "Title", projection.ImdbId);
            return View(projection);
        }

        // GET: Projection/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection projection = db.Projections.Find(id);
            if (projection == null)
            {
                return HttpNotFound();
            }
            return View(projection);
        }

        // POST: Projection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projection projection = db.Projections.Find(id);
            db.Projections.Remove(projection);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
