using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.DAL
{
    public class Projection
    {
        public int ProjectionId { get; set; }
        public System.DateTime Date { get; set; }
        public int FreeSeats { get; set; }
        public int CinemaId { get; set; }
        public string ImdbId { get; set; }

        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
    }
}