using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Utils
{
    /// <summary>
    /// This class defines the standard format to specify dates in json for these apis
    /// </summary>
    public class MovieBotJsonDateTimeConverter:IsoDateTimeConverter
    {
        /// <summary>
        /// Creates a new time converter
        /// </summary>
        public MovieBotJsonDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd HH:mm";
        }
    }
}