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
        static CinemaOutputModel cinema1 = new CinemaOutputModel()
        {
            Address = "Viale Coni Zugna 50",
            City = "Milano",
            Latitude = 45.45694f,
            Longitude = 9.1672913f
        };
        public static List<CinemaOutputModel> queryCinemaByLocation(string Region, string Province, string City, int MaxRange)
        {
            return new List<CinemaOutputModel>() { cinema1 };
        }

        public static List<CinemaOutputModel> queryCinemaByName(string Name)
        {
            return new List<CinemaOutputModel>() { cinema1 };
        }
    }
}