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
                CinemaId = Guid.NewGuid().ToString(),
                Address = "Viale Coni Zugna 50",
                City = "Milano",
                Latitude = 45.45694f,
                Longitude = 9.1672913f
            };
            Cinema cinema2 = new Cinema()
            {
                Name = "Bottarga",
                CinemaId = Guid.NewGuid().ToString(),
                Address = "Viale dei panini unti 12",
                City = "Milano",
                Latitude = 45.453428f,
                Longitude = 9.127473f
            };
            Cinema cinema3 = new Cinema()
            {
                Name = "Multisala Risotto",
                CinemaId = Guid.NewGuid().ToString(),
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
                Title = "Forrest Gump",
                ImdbId = "tt0109830",
                Genre = "Comedy",
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BYThjM2MwZGMtMzg3Ny00NGRkLWE4M2EtYTBiNWMzOTY0YTI4XkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_SX300.jpg",
                Plot = "Forrest Gump, while not intelligent, has accidentally been present at many historic moments, but his true love, Jenny Curran, eludes him.",
                Runtime = "134min"
            };
            Movie movie2 = new Movie()
            {
                Title = "Titanic",
                ImdbId = "tt0120338",
                Genre = "Drama",
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BZDNiMjE0NDgtZWRhNC00YTlhLTk2ZjItZTQzNTU2NjAzNWNkXkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_SX300.jpg",
                Plot = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                Runtime = "134min"
            };
            Movie movie3 = new Movie()
            {
                Title = "Avatar",
                ImdbId = "tt0499549",
                Genre = "Sci-Fi",
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SX300.jpg",
                Plot = "A paraplegic marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
                Runtime = "134min"
            };
            Movie movie4 = new Movie()
            {
                Title = "The Avengers",
                ImdbId = "tt0848228",
                Genre = "Action",
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTk2NTI1MTU4N15BMl5BanBnXkFtZTcwODg0OTY0Nw@@._V1_SX300.jpg",
                Plot = "Earth's mightiest heroes must come together and learn to fight as a team if they are to stop the mischievous Loki and his alien army from enslaving humanity.",
                Runtime = "134min"
            };
            Movie movie5 = new Movie()
            {
                Title = "The Matrix",
                ImdbId = "tt0133093",
                Genre = "Sci-Fi",
                Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMDMyMmQ5YzgtYWMxOC00OTU0LWIwZjEtZWUwYTY5MjVkZjhhXkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_SX300.jpg",
                Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                Runtime ="134min"
            };

            return new List<Movie>() { movie1, movie2, movie3, movie4, movie5 };

        }

        public static List<CinemaProjection> queryCinemaFromMovie(string imdbID)
        {
            List<Cinema> cinemas = getDummyCinemas();
            List<CinemaProjection> result = new List<CinemaProjection>();
            Random rnd = new Random();
            List<int> timeslots = new List<int>() { 17, 21, 23 };
            Movie movie = OmdbAdapters.GetMovieInfo(imdbID);
            foreach (var cinema in cinemas)
            {
                List<Projection> projections = new List<Projection>();
                for (int i = 0; i < 2; i++)
                {
                    projections.Add(new Projection()
                    {
                        Cinema = cinema,
                        Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeslots[rnd.Next(2)], 0, 0),
                        FreeSeats = rnd.Next(100),
                        Movie = movie
                    });
                }
                result.Add(new CinemaProjection() { Cinema = cinema, Movie = movie, Projections = projections });
            }
            return result;
                    
        }

        public static List<Movie> queryMoviesFromLocation(string Region, string Province, string City, int MaxRange)
        {
            return getDummyMovies();
        }


        public static List<Movie> queryRecommendedMoviesForUser(string userID)
        {
            return getDummyMovies();
        }
    }
}