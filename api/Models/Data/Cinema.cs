using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace api.Models.Data
{
    [Table("Cinemas")]
    public class Cinema
    {
        [Key]
        public string CinemaId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<Projection> Projections { get; set; }
    }
}