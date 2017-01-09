using api.Adapters;
using api.DAL;
using api.Models.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Tests.Controllers
{
    class Utils
    {

        public static Mock<MovieBotContext> setMockContext()
        {
            var movies = getDummyMovies().AsQueryable();
            var moviesMockSet = new Mock<DbSet<Movie>>();
            moviesMockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.Provider);
            moviesMockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.Expression);
            moviesMockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.ElementType);
            moviesMockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());
            var cinemas = getDummyCinemas().AsQueryable();
            var cinemaMockSet = new Mock<DbSet<Cinema>>();
            cinemaMockSet.As<IQueryable<Cinema>>().Setup(m => m.Provider).Returns(cinemas.Provider);
            cinemaMockSet.As<IQueryable<Cinema>>().Setup(m => m.Expression).Returns(cinemas.Expression);
            cinemaMockSet.As<IQueryable<Cinema>>().Setup(m => m.ElementType).Returns(cinemas.ElementType);
            cinemaMockSet.As<IQueryable<Cinema>>().Setup(m => m.GetEnumerator()).Returns(cinemas.GetEnumerator());

            List<Projection> projections = new List<Projection>();
            IEnumerable<CinemaProjections> cprojections = getDummyCinemaProjections(movies, cinemas);
            cprojections.ToList<CinemaProjections>().ForEach(
                c => c.MovieProjections.ToList().ForEach(
                    m => m.Projections.ToList().ForEach(
                        p => { p.ImdbId = m.Movie.ImdbId; projections.Add(p); }
                        )
                    )
                );
            var projectionsQueriable = projections.AsQueryable();
            var projectionMockSet = new Mock<DbSet<Projection>>();
            projectionMockSet.As<IQueryable<Projection>>().Setup(m => m.Provider).Returns(projectionsQueriable.Provider);
            projectionMockSet.As<IQueryable<Projection>>().Setup(m => m.Expression).Returns(projectionsQueriable.Expression);
            projectionMockSet.As<IQueryable<Projection>>().Setup(m => m.ElementType).Returns(projectionsQueriable.ElementType);
            projectionMockSet.As<IQueryable<Projection>>().Setup(m => m.GetEnumerator()).Returns(projectionsQueriable.GetEnumerator());


            var mockContext = new Mock<MovieBotContext>();
            mockContext.Setup(c => c.Movies).Returns(moviesMockSet.Object);
            mockContext.Setup(c => c.Cinemas).Returns(cinemaMockSet.Object);
            mockContext.Setup(c => c.Projections).Returns(projectionMockSet.Object);
            DatabaseAdapter.context = mockContext.Object;
            return mockContext;
        }





        private static List<Cinema> getDummyCinemas()
        {
            Cinema cinema1 = new Cinema()
            {
                Name = "Orfeo",
                CinemaId = 1,
                Address = "Viale Coni Zugna 50",
                City = "Milano",
                Latitude = 45.45694f,
                Longitude = 9.1672913f
            };
            Cinema cinema2 = new Cinema()
            {
                Name = "Bottarga",
                CinemaId = 2,
                Address = "Viale dei panini unti 12",
                City = "Milano",
                Latitude = 45.453428f,
                Longitude = 9.127473f
            };
            Cinema cinema3 = new Cinema()
            {
                Name = "Multisala Risotto",
                CinemaId = 3,
                Address = "Piazza Pino Zafferano 9",
                City = "Milano",
                Latitude = 45.482141f,
                Longitude = 9.203602f
            };
            return new List<Cinema>() { cinema1, cinema2, cinema3 };
        }

        private static IEnumerable<Movie> getDummyMovies()
        {
            List<string> imdbIds = new List<string>() { "tt0109830", "tt0120338", "tt0499549", "tt0848228", "tt0133093" };
            return imdbIds.Select<string, Movie>(imdbId => OmdbAdapters.GetMovieInfo(imdbId));

        }

        private static IEnumerable<CinemaProjections> getDummyCinemaProjections(IEnumerable<Movie> movies, IEnumerable<Cinema> cinemas)
        {
            return new List<CinemaProjections>
            {
                new CinemaProjections(
                    cinemas.ToList()[0],
                    new MovieProjections() {
                        Movie =movies.ToList()[0],
                        Projections =new List<Projection> {
                            new Projection() {
                                Cinema=cinemas.ToList()[0],
                                CinemaId=cinemas.ToList()[0].CinemaId,
                                Date=DateTime.Now,
                                FreeSeats=100,
                                ImdbId=movies.ToList()[0].ImdbId,
                                Movie=movies.ToList()[0],
                                ProjectionId=0
                            }
                        }
                    }
                )
            };
        }




        private static MovieProjections getDummyProjectionsForMovieAndCinema(Movie movie, Cinema cinema)
        {
            Random rnd = new Random();
            List<int> timeslots = new List<int>() { 17, 21, 23 };
            List<Projection> projections = new List<Projection>();
            for (int i = 0; i < timeslots.Count; i++)
            {
                projections.Add(new Projection()
                {
                    Cinema = cinema,
                    CinemaId = cinema.CinemaId,
                    Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeslots[i], 0, 0),
                    FreeSeats = rnd.Next(100),
                    Movie = movie,
                    ImdbId = movie.ImdbId
                });
            }
            return new MovieProjections() { Movie = movie, Projections = projections };
        }
    }
}

