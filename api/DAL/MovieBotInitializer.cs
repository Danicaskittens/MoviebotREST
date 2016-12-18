using api.Adapters;
using api.Models.Data;
using api.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.DAL
{
    public class MovieBotInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MovieBotContext>
    {
        protected override void Seed(MovieBotContext context)
        {
            base.Seed(context);
            List<Movie> movies = getDummyMovies().ToList();//TODO proper movie retrieval
            movies.ForEach(m => context.Movies.Add(m));
            context.SaveChanges();
            IEnumerable<Cinema> cinemas = getDummyCinemas(); //TODO proper cinema retrieval
            cinemas.ToList<Cinema>().ForEach(c => context.Cinemas.Add(c));
            context.SaveChanges();
            IEnumerable<CinemaProjections> cprojections = getDummyCinemaProjections(movies, cinemas);
            cprojections.ToList<CinemaProjections>().ForEach(
                c => c.MovieProjections.ToList().ForEach(
                    m => m.Projections.ToList().ForEach(
                        p => context.Projections.Add(p)
                        )
                    )
                );
            context.SaveChanges();
            IEnumerable<Genre> genres = getDummyGenres();
            genres.ToList<Genre>().ForEach(g => context.Genres.Add(g));
            context.SaveChanges();
            

        }
        // private dummy methods
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
            return cinemas.Select<Cinema, CinemaProjections>(
                c => new CinemaProjections(c, movies.Select<Movie, MovieProjections>(
                        m => getDummyProjectionsForMovieAndCinema(m, c)))
                );


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
                    Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeslots[i], 0, 0),
                    FreeSeats = rnd.Next(100),
                    Movie = movie
                });
            }
            return new MovieProjections() { Movie = movie, Projections = projections };
        }

        private static List<Genre> getDummyGenres()
        {
            Genre genre1 = new Genre() { GenreId = 1, Name = "Action" };
            Genre genre2 = new Genre() { GenreId = 2, Name = "Animation" };
            Genre genre3 = new Genre() { GenreId = 3, Name = "Comedy" };
            Genre genre4 = new Genre() { GenreId = 4, Name = "Drama" };
            Genre genre5 = new Genre() { GenreId = 5, Name = "Fantasy" }; 
            Genre genre6 = new Genre() { GenreId = 6, Name = "SciFi" };
            Genre genre7 = new Genre() { GenreId = 7, Name = "Thriller" }; 

            return new List<Genre>()
            {
                genre1,genre2,genre3,genre4,genre5,genre6,genre7
            };

        }


    }
}