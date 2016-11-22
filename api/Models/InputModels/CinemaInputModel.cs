using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.InputModels
{
    public class CinemaInputModel
    {


        public string Region { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int MaxRange { get; set; } = 50;
    }
}