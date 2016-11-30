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
        private static MovieBotContext context = new MovieBotContext();

        public static IEnumerable<Cinema> queryCinemaByLocation(string region, string province, string city,string state, int MaxRange)
        {
            return context.Cinemas.Where(c => c.Region == region && c.Province == province && c.City == city && c.State == state);
        }

        public static IEnumerable<Cinema> queryCinemaByName(string name)
        {
            return context.Cinemas.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }

        public static IEnumerable<Movie> queryMoviesByTitle(string title)
        {
            return context.Movies.Where(m=> m.Title.ToLower().Contains(title.ToLower()));
        }


        

        public static IEnumerable<CinemaProjections> queryCinemaFromMovie(string region, string province, string city, string state, int MaxRange, string imdbID)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(region, province, city, state, MaxRange);
            return null; //context.Projections.Where(p => p.ImdbId==imdbID && p.CinemaId == )
        }

        public static IEnumerable<Movie> queryMoviesFromLocation(string region, string province, string city, string state, int MaxRange)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(region, province, city, state, MaxRange);
            return context.Projections.Where(p=> cinemas.Where(c=> c.CinemaId == p.CinemaId).Count()>0).Select<Projection,Movie>(p=> p.Movie).Distinct();
        }


        public static IEnumerable<Movie> queryRecommendedMoviesForUser(string userID)
        {
            return context.Movies.Where(m => m.Genre=="Action");
        }
    }
}