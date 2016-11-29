using api.Adapters;
using api.Models.Data;
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
            List<Movie> movies = DatabaseAdapter.queryMoviesByTitle("");//TODO proper movie retrieval
            movies.ForEach(m => context.Movies.Add(m));
            
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByName(""); //TODO proper cinema retrieval
            cinemas.ToList<Cinema>().ForEach(c => context.Cinemas.Add(c));

            IEnumerable<Cinema> projections = DatabaseAdapter.

            context.SaveChanges();
        }
    }
}