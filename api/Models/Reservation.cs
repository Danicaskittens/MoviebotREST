using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string cinemaId { get; set; }
        public string movieId { get; set; }
        public string projectionTime { get; set; }
        public string timeStamp { get; set; }
        public string status { get; set; }

        
    }
}