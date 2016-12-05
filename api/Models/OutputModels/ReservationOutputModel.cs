using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace api.Models.OutputModels
{
    public class ReservationOutputModel
    {
        private Reservation reservation;
        public ReservationOutputModel(Reservation reservation)
        {
            this.reservation = reservation;
        }
        public string ReservationID { get { return this.reservation.ReservationID; } }
        public int Quantity { get { return this.reservation.Quantity; } }
        public string Date { get { return this.reservation.TimeStamp.ToString("yyyy/MM/dd"); } }
        public string Time { get { return this.reservation.TimeStamp.ToString("HH:mm"); } }
        public string Status { get { return this.reservation.StatusType.ToString(); } }
       
    }
}