using api.Models.Data;
using api.Models.InputModels;
using api.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Adapters
{
    public class DatabaseAdapter
    {


        public static List<Cinema> queryCinemaByLocation(string Region, string Province, string City, int MaxRange)
        {
            return getDummyCinemas();
        }

        public static IEnumerable<Cinema> queryCinemaByName(string Name)
        {
            return from cinema in getDummyCinemas()
                   where cinema.Name.ToLower().Contains(Name.ToLower())
                   select cinema;
        }

        public static List<Movie> queryMoviesByTitle(string title)
        {
            return getDummyMovies();
        }


        // private dummy methods
        private static List<Cinema> getDummyCinemas()
        {
            Cinema cinema1 = new Cinema()
            {
                Name = "Orfeo",
                CinemaID = Guid.NewGuid().ToString(),
                Address = "Viale Coni Zugna 50",
                City = "Milano",
                Latitude = 45.45694f,
                Longitude = 9.1672913f
            };
            Cinema cinema2 = new Cinema()
            {
                Name = "Bottarga",
                CinemaID = Guid.NewGuid().ToString(),
                Address = "Viale dei panini unti 12",
                City = "Milano",
                Latitude = 45.453428f,
                Longitude = 9.127473f
            };
            Cinema cinema3 = new Cinema()
            {
                Name = "Multisala Risotto",
                CinemaID = Guid.NewGuid().ToString(),
                Address = "Piazza Pino Zafferano 9",
                City = "Milano",
                Latitude = 45.482141f,
                Longitude = 9.203602f
            };
            return new List<Cinema>() { cinema1, cinema2, cinema3 };
        }

        private static List<Movie> getDummyMovies()
        {
            Movie movie1 = new Movie()
            {
                Title = "The Avengers Uno",
                ImdbID = "tt0848228"
            };
            Movie movie2 = new Movie()
            {
                Title = "The Avengers Due",
                ImdbID = "tt2395427"
            };
            Movie movie3 = new Movie()
            {
                Title = "The Avengers Tre",
                ImdbID = "tt4154756"
            };

            return new List<Movie>() { movie1, movie2, movie3 };

        }

        public static List<CinemaProjection> queryCinemaFromMovie(string imdbID)
        {
            List<Cinema> cinemas = getDummyCinemas();
            List<CinemaProjection> result = new List<CinemaProjection>();
            Random rnd = new Random();
            List<int> timeslots = new List<int>() { 17, 21, 23 };
            foreach (var cinema in cinemas)
            {
                List<Projection> projections = new List<Projection>();
                for (int i = 0; i < 2; i++)
                {
                    projections.Add(new Projection()
                    {
                        CinemaID = cinema.CinemaID,
                        Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeslots[rnd.Next(2)], 0, 0),
                        FreeSeats = rnd.Next(100),
                        ImdbID = imdbID
                    });
                }
                result.Add(new CinemaProjection() { Cinema = cinema, ImdbId = imdbID, Projections = projections });
            }
            return result;
                    
        }

        public static List<Movie> queryMoviesFromLocation(string Region, string Province, string City, int MaxRange)
        {
            return getDummyMovies();
        }
    }
}