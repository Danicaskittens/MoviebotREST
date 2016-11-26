using System;

namespace api.Models.Data
{
    public class Projection
    {
        public string ImdbID { get; set; }
        public string CinemaID { get; set; }
        public DateTime Date { get; set; }
        public int FreeSeats { get; set; }

    }
}