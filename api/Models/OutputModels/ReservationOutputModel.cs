using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using api.DAL;

namespace api.Models.OutputModels
{
    /// <summary>
    /// Reservation information
    /// </summary>
    public class ReservationOutputModel
    {
        private Reservation reservation;
        /// <summary>
        /// Don't use this, please, this is only to create the preview of the response
        /// </summary>
        public ReservationOutputModel()
        {
            this.reservation = new Reservation();
        }
        /// <summary>
        /// Creates a new reservation output model based on a reservation object
        /// </summary>
        /// <param name="reservation"></param>
        public ReservationOutputModel(Reservation reservation)
        {
            this.reservation = reservation;
        }
        /// <summary>
        /// Id of the reservation
        /// </summary>
        public int ReservationId { get { return this.reservation.ReservationId; } }
        /// <summary>
        /// Number of reserved seats
        /// </summary>
        public int Quantity { get { return this.reservation.Quantity; } }
        /// <summary>
        /// Date on which the movie is projected in the yyyy-MM-dd format
        /// </summary>
        public string Date { get { return this.reservation.ProjectionDateTime.ToString("yyyy-MM-dd"); } }
        /// <summary>
        /// Time on which the movie is projected in the HH:mm format
        /// </summary>
        public string Time { get { return this.reservation.ProjectionDateTime.ToString("HH:mm"); } }
        /// <summary>
        /// Status of the reservation(string type): 
        /// "InProcess" when the process begins
        /// "Complete" after the payment
        /// </summary>
        public string Status { get { return this.reservation.StatusType.ToString(); } }
        /// <summary>
        /// Id of the reserved projection 
        /// </summary>
        public int ProjectionId { get { return this.reservation.ProjectionId; } }
        /// <summary>
        /// City of the reserved projection
        /// </summary>
        public string City { get { return this.reservation.ProjectionCity; } }
        /// <summary>
        /// Cinema name of the reserved projection
        /// </summary>
        public string Cinema { get { return this.reservation.ProjectionCinema; } }
        /// <summary>
        /// Movie title of the reserved projection
        /// </summary>
        public string Movie { get { return this.reservation.ProjectionMovie; } }

    }
}