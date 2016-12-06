using api.DAL;
using api.Models.Data;
using api.Models.InputModels;
using api.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Adapters
{
    /// <summary>
    /// Methods to retrieve complex info from the data access layer
    /// </summary>
    public class DatabaseAdapter
    {
        private static MovieBotContext context = new MovieBotContext();

        private static bool inRangeOf(double number, double center, int range)
        {
            return (number < center + range) && (number > center - range);
        }
        /// <summary>
        /// Retrieves the list of cinemas near a specific location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="MaxRange"></param>
        /// <returns></returns>
        public static IEnumerable<Cinema> queryCinemaByLocation(double latitude, double longitude, int MaxRange)
        {
            return context.Cinemas.Where(c => inRangeOf(c.Latitude,latitude,MaxRange) && inRangeOf(c.Latitude, latitude, MaxRange));
        }
        /// <summary>
        /// Retrieves the list of cinemas whose name contains the provided search argument
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<Cinema> queryCinemaByName(string name)
        {
            return context.Cinemas.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }
        /// <summary>
        /// Searches the list of currently shown movies for a movie with the provided title or part of it
        /// and returns a list of movies
        /// </summary>
        /// <param name="title">complete title or part of it</param>
        /// <returns></returns>
        public static IEnumerable<Movie> queryMoviesByTitle(string title)
        {
            return context.Movies.Where(m => m.Title.ToLower().Contains(title.ToLower()));
        }
        /// <summary>
        /// Returns the list of cinemas and their projections for a specific movie
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="maxRange"></param>
        /// <param name="imdbID"></param>
        /// <returns></returns>
        public static IEnumerable<CinemaProjections> queryCinemaFromMovie(double latitude, double longitude, int maxRange, string imdbID)
        { //TODO change this into an aggregate function if possible
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(latitude, longitude, maxRange);
            IQueryable<Cinema> movieCinemas = context.Cinemas.Where(c => context.Projections.Where(p => p.ImdbId == imdbID && p.CinemaId == c.CinemaId).Any());
            Movie movie = context.Movies.Where(m => m.ImdbId == imdbID).ElementAt(0);
            return movieCinemas.Select<Cinema, CinemaProjections>(mc => new CinemaProjections(mc, queryMovieProjectionsFromMovieAndCinema(mc, movie)));
        }
        /// <summary>
        /// Returns the projections for a specific movie in a specific cinema
        /// </summary>
        /// <param name="cinema"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        public static MovieProjections queryMovieProjectionsFromMovieAndCinema(Cinema cinema, Movie movie)
        {
            return cinema.Projections.Where(p => p.ImdbId == movie.ImdbId && p.CinemaId == cinema.CinemaId)
                .Aggregate(
                    new MovieProjections() { Movie = movie, Projections = new List<Projection>() },
                    (current, next) =>
                    {
                        current.Projections.Add(next);
                        return current;
                    }
                );
        }
        /// <summary>
        /// Returns the movies that are shown the cinemas near a particular location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="maxRange"></param>
        /// <returns></returns>
        public static IEnumerable<Movie> queryMoviesFromLocation(double latitude, double longitude, int maxRange)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(latitude,longitude, maxRange);
            return context.Projections.Where(p => cinemas.Where(c => c.CinemaId == p.CinemaId).Any()).Select<Projection, Movie>(p => p.Movie).Distinct();
        }

        public static IEnumerable<Movie> queryRecommendedMoviesForUser(string userID)
        {
            return context.Movies.Where(m => m.Genre == "Action");
        }
    }
}