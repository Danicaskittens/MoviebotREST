﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CinemaInterfaceServerModelContainer : DbContext
    {
        public CinemaInterfaceServerModelContainer()
            : base("name=CinemaInterfaceServerModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Movie> MovieSet { get; set; }
        public virtual DbSet<Cinema> CinemaSet { get; set; }
        public virtual DbSet<Projection> ProjectionSet { get; set; }
    }
}