using api.Adapters;
using api.DAL;
using api.Models.Data;
using api.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace api.Controllers
{
    public class RandomShitController : Controller
    {
        static Random rnd = new Random();
        // GET: RandomShit
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult addProjectionsForDay()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addProjectionsForDay([Bind(Include = "StartDate,EndDate")]DateRangeInputModel dateRange)
        {
            MovieBotContext context = new MovieBotContext();
            foreach (var date in DatabaseAdapter.EachDay(dateRange.StartDate, dateRange.EndDate))
            {
                IEnumerable<Movie> movies = context.Movies.ToList();
                IEnumerable<Cinema> cinemas = context.Cinemas.ToList();
                IEnumerable<CinemaProjections> cprojections = getDummyCinemaProjections(movies, cinemas,date);
                cprojections.ToList<CinemaProjections>().ForEach(
                    c => c.MovieProjections.ToList().ForEach(
                        m => m.Projections.ToList().ForEach(
                            p => context.Projections.Add(p)
                            )
                        )
                    );
            }
            context.SaveChanges();
            return View();
        }


        private IEnumerable<CinemaProjections> getDummyCinemaProjections(IEnumerable<Movie> movies, IEnumerable<Cinema> cinemas,DateTime date)
        {
            return cinemas.Select<Cinema, CinemaProjections>(
                c => new CinemaProjections(c, movies.Select<Movie, MovieProjections>(
                        m => getDummyProjectionsForMovieAndCinema(m, c,date)))
                );


        }

        private MovieProjections getDummyProjectionsForMovieAndCinema(Movie movie, Cinema cinema,DateTime date)
        {

            List<int> timeslots = new List<int>() { 17, 21, 23 };
            List<Projection> projections = new List<Projection>();
            for (int i = 0; i < timeslots.Count; i++)
            {
                if (rnd.Next(5000) > 2500)
                {
                    projections.Add(new Projection()
                    {
                        Cinema = cinema,
                        Date = new DateTime(date.Year, date.Month, date.Day, timeslots[i], 0, 0),
                        FreeSeats = rnd.Next(100),
                        Movie = movie
                    });
                }

            }
            return new MovieProjections() { Movie = movie, Projections = projections };
        }
    }
}