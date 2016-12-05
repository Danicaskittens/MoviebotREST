using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using api.DAL;

namespace api.Models.OutputModels
{
    public class ReservationOutputModel
    {
        private Reservation reservation;
        public ReservationOutputModel(Reservation reservation)
        {
            this.reservation = reservation;
        }
        public int ReservationId { get { return this.reservation.ReservationId; } }
        public int Quantity { get { return this.reservation.Quantity; } }
        public string Date { get { return this.reservation.TimeStamp.ToString("yyyy/MM/dd"); } }
        public string Time { get { return this.reservation.TimeStamp.ToString("HH:mm"); } }
        public string Status { get { return this.reservation.StatusType.ToString(); } }
       
    }
}