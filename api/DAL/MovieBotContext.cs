using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace api.DAL
{
    public class MovieBotContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Projection> Projections { get; set; }
    }
}