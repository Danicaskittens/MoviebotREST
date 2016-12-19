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
        
        /// <summary>
        /// Returns the chosen projection
        /// </summary>
        /// <param name="projectionId">Id of the specific projection</param>
        /// <returns></returns>
        public static Projection QueryProjection(int projectionId)
        {
            return context.Projections.Find(projectionId);
        }

        public static Reservation QueryReservation(int reservationId)
        {
            return context.Reservations.Find(reservationId);
        }
 
        /// <summary>
        /// Initializes a new reservation for the user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <param name="projectionId">Id of the specific projection </param>
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
                    UserId = userId
                };

                context.Reservations.Add(reservation);
                context.SaveChanges();

            }
      
        }

        /// <summary>
        /// Complete the reservation process:
        /// set number of seats, update status to "complete,
        /// set the timestamp,
        /// update number of free seats for the chosen projection
        /// </summary>
        /// <param name="reservationId"></param>
        /// <param name="quantity"></param>
        public static void CompleteReservation(int reservationId, int quantity)
        {
            Reservation reservation = context.Reservations.Find(reservationId);
            reservation.Quantity = quantity;
            reservation.StatusType = Reservation.Status.Complete;
            //reservation.TimeStamp = DateTime.Now;
            
            Projection projection = context.Projections.Find(reservation.ProjectionId);
            projection.FreeSeats -= quantity;

            context.SaveChanges();

        }



    }
}