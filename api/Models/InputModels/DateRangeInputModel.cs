using api.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.InputModels
{
    /// <summary>
    /// Standard way to provide a date range information to the apis, the range must include also the start and end date.
    /// To provide for an unique date, the Start and End date can be set to the same value
    /// 
    /// Also every date must be in the format: yyyy-MM-dd HH:mm
    /// </summary>
    public class DateRangeInputModel
    {
        /// <summary>
        /// Returns the default value of the date range (with start and end date that are set to today)
        /// </summary>
        /// <returns></returns>
        public static DateRangeInputModel DefaultValue()
        {
            return new DateRangeInputModel() { StartDate = DateTime.Now, EndDate = DateTime.Now };
        }
        /// <summary>
        /// Start date of the range 
        /// </summary>
        [JsonConverter(typeof(MovieBotJsonDateTimeConverter))]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date of the range 
        /// </summary>
        [JsonConverter(typeof(MovieBotJsonDateTimeConverter))]
        public DateTime EndDate { get; set; }
    }
}