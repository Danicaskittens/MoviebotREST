using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Data
{
    public class Cinema
    {
        public string Name { get; set; }
        public string CinemaID { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
    }
}