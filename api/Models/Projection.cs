using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Projection
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public int Slot { get; set; }
        public string Date { get; set; }
        
    }
}