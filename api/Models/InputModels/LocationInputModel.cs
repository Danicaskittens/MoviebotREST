using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.InputModels
{
    /// <summary>
    /// Standard way to select a location for this apis
    /// </summary>
    public class LocationInputModel
    {
        /// <summary>
        /// Latitude part of the coordinates (ex. 48.4017343)
        /// </summary>
        public float Latitude { get; set; }
        /// <summary>
        /// Longitude part of the coordinates (ex 20.2327984)
        /// </summary>
        public float Longitude { get; set; }
        /// <summary>
        /// Maximum acceptable range for the results (in km), by default 50km
        /// </summary>
        public int MaxRange { get; set; } = 50;
    }
}