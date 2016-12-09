using api.DAL;
using api.Models;
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
        public static IQueryable<Cinema> queryCinemaByLocation(double latitude, double longitude, double MaxRange)
        {
            double minx = latitude - MaxRange / 111.111;
            double maxx = latitude + MaxRange / 111.111;
            double miny = longitude - MaxRange / 111.111;
            double maxy = longitude + MaxRange / 111.111;
            return context.Cinemas.Where(c => (c.Latitude < (maxx))).Where(c => (c.Latitude > (minx)))
                .Where(c => (c.Longitude < (maxy))).Where(c => (c.Longitude > (miny)));
        }
        /// <summary>
        /// Retrieves the list of cinemas whose name contains the provided search argument
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IQueryable<Cinema> queryCinemaByName(string name)
        {
            return context.Cinemas.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }


        /// <summary>
        /// Retrieves the list of projections for the selected cinema, and selected imdbId, shown on the specified date range
        /// </summary>
        /// <param name="cinemaId">Id of the cinema to retrieve the projection from</param>
        /// <param name="imdbId">Id of the movie to retrieve the projections</param>
        /// <param name="startDate">Starting date of the range</param>
        /// <param name="endDate">Ending date of the range</param>
        /// <returns></returns>
        public static IQueryable<Projection> queryProjectionsByCinemaAndMovieAndDateRange(int cinemaId, string imdbId, DateTime startDate, DateTime endDate)
        {
            return context.Projections.Where(p => p.CinemaId == cinemaId && p.ImdbId == imdbId).Where(p => p.Date > startDate && p.Date <= endDate);
        }

        /// <summary>
        /// Searches the list of currently shown movies for a movie with the provided title or part of it
        /// and returns a list of movies
        /// </summary>
        /// <param name="title">complete title or part of it</param>
        /// <returns></returns>
        public static IQueryable<Movie> queryMoviesByTitle(string title)
        {
            return context.Movies.Where(m => m.Title.ToLower().Contains(title.ToLower()));
        }

        /// <summary>
        /// Returns the list of movies currently projected in a cinema
        /// </summary>
        /// <param name="cinema">Cinema to retrieve the list of movies from</param>
        /// <param name="startDate">Initial day of the date range</param>
        /// <param name="endDate">Final day of the date range</param>
        /// <returns></returns>
        public static IQueryable<Movie> queryMoviesInCinema(Cinema cinema, DateTime startDate, DateTime endDate)
        {
            return queryProjectionsInCinemaAndDateRange(cinema, startDate, endDate).Select<Projection, Movie>(p => p.Movie).Distinct();
        }

        /// <summary>
        /// Returns the list of cinemas near a specific location that show a specific movie on a specified date range
        /// </summary>
        /// <param name="latitude">latitude of the center of the search radius</param>
        /// <param name="longitude">longitude of the center of the search radius</param>
        /// <param name="maxRange">maximum radius of the search area (in kilometers)</param>
        /// <param name="imdbId">imdbId of the movie to search</param>
        /// <param name="startDate">starting date of the date range</param>
        /// <param name="endDate">ending date of the date range</param>
        /// <returns></returns>
        public static IEnumerable<Cinema> queryCinemaFromMovie(double latitude, double longitude, int maxRange, string imdbId, DateTime startDate, DateTime endDate)
        {
            IQueryable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(latitude, longitude, maxRange);
            return context.Cinemas.Where(c => context.Projections.Where(p => p.ImdbId == imdbId && p.CinemaId == c.CinemaId)
                                    .Where(p => p.Date > startDate && p.Date <= endDate).Any());
        }

        /// <summary>
        /// Returns the list of cinemas and their projections for a specific movie
        /// </summary>
        /// <param name="latitude">latitude of the center of the search radius</param>
        /// <param name="longitude">longitude of the center of the search radius</param>
        /// <param name="maxRange">maximum radius of the search area (in kilometers)</param>
        /// <param name="imdbId">imdbId of the movie to search</param>
        /// <param name="startDate">starting date of the date range</param>
        /// <param name="endDate">ending date of the date range</param>
        /// <returns></returns>
        public static IQueryable<CinemaProjections> queryCinemaProjectionsFromMovie(double latitude, double longitude, int maxRange, string imdbId, DateTime startDate, DateTime endDate)
        { //TODO change this into an aggregate function if possible
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(latitude, longitude, maxRange);
            IQueryable<Cinema> movieCinemas = context.Cinemas.Where(c => queryProjectionsInCinemaAndDateRange(c, startDate, endDate)
                                                                        .Where(p => p.ImdbId == imdbId && p.CinemaId == c.CinemaId).Any());
            Movie movie = context.Movies.Where(m => m.ImdbId == imdbId).ElementAt(0);
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
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(latitude, longitude, maxRange);
            return context.Projections.Where(p => cinemas.Where(c => c.CinemaId == p.CinemaId).Any()).Select<Projection, Movie>(p => p.Movie).Distinct();
        }

        /// <summary>
        /// Returns the movie object relative to the specified imdb (from the apis database and not from omdb)
        /// </summary>
        /// <param name="imdbId">imdb of the movie to search for</param>
        /// <returns></returns>
        public static Movie queryMovieByImdbId(string imdbId)
        {
            return context.Movies.Find(imdbId);
        }

        /// <summary>
        /// Returns the cinema object from the provided CinemaId
        /// </summary>
        /// <param name="cinemaId"></param>
        /// <returns></returns>
        public static Cinema queryCinemaByCinemaId(int cinemaId)
        {
            return context.Cinemas.Find(cinemaId);
        }

        /// <summary>
        /// Returns the list of projections between two dates in a given cinema (beware, this will generate error if nested in another query)
        /// </summary>
        /// <param name="cinema">Cinema whose projections it's filtering</param>
        /// <param name="startDate">initial date of the range</param>
        /// <param name="endDate">initial date of the range</param>
        /// <returns></returns>
        public static IQueryable<Projection> queryProjectionsInCinemaAndDateRange(Cinema cinema, DateTime startDate, DateTime endDate)
        {
            return from p in context.Projections
                   where p.CinemaId == cinema.CinemaId &&
                    p.Date >= startDate && p.Date <= endDate
                   select p;

        }
        /// <summary>
        /// Creates an iterator that iterates exactly each day of the range (if from and thru are equal, it will iterate only once)
        /// </summary>
        /// <param name="from">Start date of the range</param>
        /// <param name="thru">End date of the range</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        /// <summary>
        /// Returns the projection from the id of the projection
        /// </summary>
        /// <param name="projectionId">Id of the projection to retrieve</param>
        /// <returns></returns>
        public static Projection queryProjectionByProjectionId(int projectionId)
        {
            return context.Projections.Find(projectionId);
        }


        public static IEnumerable<Movie> queryRecommendedMoviesForUser(string userID)
        {
            return context.Movies.Where<Movie>(m => m.Genre.ToLower().Contains("action"));
        }

    }
}