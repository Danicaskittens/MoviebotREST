using api.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// Returns the reservation
        /// </summary>
        /// <param name="reservationId">Id of the specific reservation</param>
        /// <returns></returns>
        public static Reservation QueryReservation(int reservationId)
        {
            return context.Reservations.Find(reservationId);
        }


        /// <summary>
        /// Initializes a new reservation for the user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <param name="projectionId">Id of the specific projection </param>
        /// <returns>the new reservation</returns>
        public static Reservation AddNewReservation(string userId, int projectionId)
        {
            Projection projection = context.Projections.Find(projectionId);

            if (projection != null)
            {
                string city = context.Cinemas.Find(projection.CinemaId).City;
                string cinema = context.Cinemas.Find(projection.CinemaId).Name;
                string movie = OmdbAdapters.GetMovieInfo(projection.ImdbId).Title;

                Reservation reservation = new Reservation()
                {
                    Projection = projection,
                    ProjectionId = projectionId,
                    StatusType = Reservation.Status.InProcess,
                    UserId = userId,
                    TimeStamp = DateTime.Now,
                    ProjectionDateTime = projection.Date,
                    ProjectionCity = city,
                    ProjectionCinema = cinema,
                    ProjectionMovie = movie
                    
                };

                context.Reservations.Add(reservation);
                context.SaveChanges();
                return reservation;
            }
            return null;
      
        }

        /// <summary>
        /// Complete the reservation process:
        /// set number of seats, update status to "complete",
        /// update the number of free seats for the chosen projection
        /// </summary>
        /// <param name="reservation">Reservation to complete</param>
        /// <param name="quantity">Number of seats</param>
        public static void CompleteReservation(Reservation reservation, int quantity)
        {
            reservation.Quantity = quantity;
            reservation.StatusType = Reservation.Status.Complete;
            
            Projection projection = QueryProjection(reservation.ProjectionId);
            projection.FreeSeats -= quantity;

            context.SaveChanges();

        }

        /// <summary>
        /// Cancel the reservation in process or already completed:
        /// update status to "canceled",
        /// restore the number of free seats for the chosen projection
        /// </summary>
        /// <param name="reservation">Reservation to cancel</param>
        public static void CancelReservation(Reservation reservation)
        {
            reservation.StatusType = Reservation.Status.Canceled;

            Projection projection = QueryProjection(reservation.ProjectionId);
            projection.FreeSeats += reservation.Quantity;

            context.Reservations.Remove(reservation);

            context.SaveChanges();
        }



    }
}