using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Data
{
    [Table("Projections")]
    public class Projection
    {
        [Key]
        public string ProjectionId { get; set; }
        public string CinemaId { get; set; }
        public string ImdbId { get; set; }
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
        public DateTime Date { get; set; }
        public int FreeSeats { get; set; }
    }
}