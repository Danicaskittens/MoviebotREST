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
        /// Generates a new DateRangeInputModel with today as start date and end date
        /// </summary>
        public DateRangeInputModel()
        {
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;
        }
        /// <summary>
        /// Returns the default value of the date range (with start and end date that are set to today)
        /// </summary>
        /// <returns></returns>
        public static DateRangeInputModel DefaultValue
        {
            get { return new DateRangeInputModel() { StartDate = DateTime.Now.Date, EndDate = DateTime.Now.Date }; }
        }

        public Boolean isEmpty()
        {
            if (StartDate == null || EndDate == null)
            {
                return true;
            }
            if (StartDate.Equals(new DateTime()) && EndDate.Equals(new DateTime()))
            {
                return true;
            }
            return false;
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