using api.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Adapters
{
    /// <summary>
    /// This adapter contains every function regarding the reservations management
    /// </summary>
    public class ReservationsAdapter
    {
        private static MovieBotContext context = new MovieBotContext();

        /// <summary>
        /// Returns all the reservations of a specific user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns></returns>
        public static IEnumerable<Reservation> QueryReservationsByUserId(string userId)
        {
            return context.Reservations.Where(r => r.UserId == userId);
        }

        //NOT TESTED
        public static void AddNewReservation(string userId, int projectionId)
        {
            Projection projection = context.Projections.Find(projectionId);

            if (projection != null)
            {
                Reservation reservation = new Reservation()
                {
                    Projection = projection,
                    ProjectionId = projectionId,
                    StatusType = Reservation.Status.InProcess,
                    //TimeStamp = DateTime.Now,
                    UserId = userId
                };

                context.Reservations.Add(reservation);
                context.SaveChanges();

            }
      
        }



    }
}