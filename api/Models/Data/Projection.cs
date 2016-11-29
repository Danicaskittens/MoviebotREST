using System;
using System.Collections.Generic;

namespace api.Models.Data
{
    public class Projection
    {
        public string CinemaId { get; set; }
        public string ImdbId { get; set; }
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
        public DateTime Date { get; set; }
        public int FreeSeats { get; set; }
        public ICollection<Projection> Projections { get; set; }
    }
}