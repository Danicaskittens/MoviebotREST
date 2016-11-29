using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.OutputModels
{
    public class CinemaOutputModel
    {
        private Cinema cinema;
        public CinemaOutputModel(Cinema cinema)
        {
            this.cinema = cinema;
        }
        public string Name { get { return this.cinema.Name; } }

        public string CinemaID { get { return this.cinema.CinemaId; } }
        public string Address { get { return this.cinema.Address; } }
        public float Latitude { get { return this.cinema.Latitude; } }
        public float Longitude { get { return this.cinema.Longitude; } }
        public string PhoneNumber { get { return this.cinema.PhoneNumber; } }
        public string Region { get { return this.cinema.Region; } }
        public string Province { get { return this.cinema.Province; } }
        public string City { get { return this.cinema.City; } }
    }
}