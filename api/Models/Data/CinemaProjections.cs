using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using api.DAL;

namespace api.Models.Data
{
    public class CinemaProjections
    {
        public CinemaProjections(Cinema cinema, MovieProjections movieProjections)
        {
            this.Cinema = cinema;
            this.MovieProjections = new List<MovieProjections>() { movieProjections };
        }
        public CinemaProjections(Cinema cinema, IEnumerable<MovieProjections> movieProjections)
        {
            this.Cinema = cinema;
            this.MovieProjections =  movieProjections ;
        }

        public Cinema Cinema { get; set; }
        public IEnumerable<MovieProjections> MovieProjections { get; set; }

    }
}