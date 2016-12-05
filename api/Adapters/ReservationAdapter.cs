using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.DAL;

namespace api.Adapters
{
    public class ReservationAdapter
    {

        public void createNewReservation(string userID, string ProjectionID)
        {
            Reservation reservation = new Reservation()
            {
                ReservationId = 123456,
                Quantity = 2,
                StatusType = Reservation.Status.InProcess,
                TimeStamp = DateTime.Now
               

            };
        }

    }
}