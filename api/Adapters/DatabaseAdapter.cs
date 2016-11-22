using api.Models.Data;
using api.Models.InputModels;
using api.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Adapters
{
    public class DatabaseAdapter
    {
        static Cinema cinema1 = new Cinema()
        {
            Address = "Viale Coni Zugna 50",
            City = "Milano",
            Latitude = 45.45694f,
            Longitude = 9.1672913f
        };
        public static List<Cinema> queryCinemaByLocation(string Region, string Province, string City, int MaxRange)
        {
            return new List<Cinema>() { cinema1 };
        }

        public static List<Cinema> queryCinemaByName(string Name)
        {
            return new List<Cinema>() { cinema1 };
        }
    }
}