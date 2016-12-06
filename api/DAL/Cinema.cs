using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.DAL
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        
        public virtual List<Projection> Projections { get; set; }
    }
}