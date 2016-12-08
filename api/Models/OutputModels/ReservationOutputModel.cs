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
        /// Date on which this specific reservation process begins (yyyy-MM-dd format)
        /// </summary>
        public string Date { get { return this.reservation.TimeStamp.ToString("yyyy/MM/dd"); } }
        /// <summary>
        /// Time on which this specific reservation process begins (HH:mm format)
        /// </summary>
        public string Time { get { return this.reservation.TimeStamp.ToString("HH:mm"); } }
        /// <summary>
        /// Status of the reservation(string type): 
        /// "InProcess" when the process begins
        /// "Complete" after the payment
        /// </summary>
        public string Status { get { return this.reservation.StatusType.ToString(); } }
        /// <summary>
        /// Reserved movie projection
        /// </summary>
        public int ProjectionId { get { return this.reservation.ProjectionId; } }
        /// <summary>
        /// User who makes this reservation
        /// </summary>
        public int UserId { get { return this.reservation.UserId; } }

    }
}