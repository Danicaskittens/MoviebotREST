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
    public class DatabaseAdapter
    {
        private static CinemaInterfaceServerModelContainer context = new CinemaInterfaceServerModelContainer();

        public static IEnumerable<Cinema> queryCinemaByLocation(string region, string province, string city, string state, int MaxRange)
        {
            return context.CinemaSet.Where(c => c.Region == region && c.Province == province && c.City == city && c.State == state);
        }

        public static IEnumerable<Cinema> queryCinemaByName(string name)
        {
            return context.CinemaSet.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }

        public static IEnumerable<Movie> queryMoviesByTitle(string title)
        {
            return context.MovieSet.Where(m => m.Title.ToLower().Contains(title.ToLower()));
        }

        public static IEnumerable<CinemaProjections> queryCinemaFromMovie(string region, string province, string city, string state, int MaxRange, string imdbID)
        { //TODO change this into an aggregate function if possible
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(region, province, city, state, MaxRange);
            IQueryable<Cinema> movieCinemas = context.CinemaSet.Where(c => context.ProjectionSet.Where(p => p.ImdbId == imdbID && p.CinemaId == c.CinemaId).Any());
            Movie movie = context.MovieSet.Where(m => m.ImdbId == imdbID).ElementAt(0);
            return movieCinemas.Select<Cinema, CinemaProjections>(mc => new CinemaProjections(mc, queryMovieProjectionsFromMovieAndCinema(mc, movie)));
        }

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

        public static IEnumerable<Movie> queryMoviesFromLocation(string region, string province, string city, string state, int MaxRange)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(region, province, city, state, MaxRange);
            return context.ProjectionSet.Where(p => cinemas.Where(c => c.CinemaId == p.CinemaId).Any()).Select<Projection, Movie>(p => p.Movie).Distinct();
        }

        public static IEnumerable<Movie> queryRecommendedMoviesForUser(string userID)
        {
            return context.MovieSet.Where(m => m.Genre == "Action");
        }
    }
}