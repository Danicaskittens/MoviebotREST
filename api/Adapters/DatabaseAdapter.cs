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

        public static List<Cinema> queryCinemaByName(string Name)
        {
            return getDummyCinemas();
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
                Address = "Viale Coni Zugna 50",
                City = "Milano",
                Latitude = 45.45694f,
                Longitude = 9.1672913f
            };
            return new List<Cinema>() { cinema1 };
        }

        private static List<Movie> getDummyMovies()
        {
            Movie movie1 = new Movie()
            {
                Title ="The Avengers Uno",
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

        public static List<Movie> queryMoviesByLocation(LocationInputModel location)
        {
            return getDummyMovies();
        }
    }
}