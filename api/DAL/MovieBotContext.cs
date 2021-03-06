﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace api.DAL
{
    /// <summary>
    /// The Entity framework context for everything concerning the moviebot database
    /// </summary>
    public class MovieBotContext : DbContext
    {
        /// <summary>
        /// Creates a new Moviebotcontext using the MovieBotDb database on default initializator connection (see web.config for details)
        /// </summary>
        public MovieBotContext():base("MovieBotContext"){
            Database.SetInitializer<MovieBotContext>(new MovieBotInitializer());
        }
        /// <summary>
        /// List of Cinemas actually present on the database
        /// </summary>
        public virtual DbSet<Cinema> Cinemas { get; set; }
        /// <summary>
        /// List of the movies actually present on the database
        /// </summary>
        public virtual DbSet<Movie> Movies { get; set; }
        /// <summary>
        /// List of projections present on the database
        /// </summary>
        public virtual DbSet<Projection> Projections { get; set; }
        /// <summary>
        /// List of reservations present on the database
        /// </summary>
        public virtual DbSet<Reservation> Reservations { get; set; }
        /// <summary>
        /// All the types of genres present on the database
        /// </summary>
        public virtual DbSet<Genre> Genres { get; set; }
        /// <summary>
        /// User profiles of favorite genres present on the database
        /// </summary>
        public virtual DbSet<FavoriteGenres> FavoriteGenres { get; set; }
    }
}