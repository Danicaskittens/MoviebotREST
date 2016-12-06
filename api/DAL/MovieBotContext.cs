using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace api.DAL
{
    public class MovieBotContext : DbContext
    {
        public MovieBotContext():base("MovieBotDb"){
            Database.SetInitializer<MovieBotContext>(new MovieBotInitializer());
        }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Projection> Projections { get; set; }
    }
}