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
        public static List<CinemaOutputModel> queryCinemaByLocation(string Region, string Province, string City, int MaxRange)
        {
            CinemaOutputModel cinema1 = new CinemaOutputModel()
            {
                Address = "Viale Coni Zugna 50",
                City = "Milano",
                Latitude = 45.45694f,
                Longitude = 9.1672913f
            };
            return new List<CinemaOutputModel>() { cinema1 };
        }
    }
}