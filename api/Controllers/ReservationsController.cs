using api.Adapters;
using api.DAL;
using api.Models.OutputModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace api.Controllers
{
    [Authorize]
    [RoutePrefix("api/v2/reservations")]
    public class ReservationsController : ApiController
    {
        /// <summary>
        /// Returns all the reservations made by the user
        /// </summary>
        /// <returns></returns>
        [Route("getByUserId")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<ReservationOutputModel>>))]
        [HttpGet]
        public IHttpActionResult GetAllReservationsByUserId()
        {
            return Ok(new JsonApiOutput<IEnumerable<ReservationOutputModel>>(
                ReservationsAdapter.QueryReservationsByUserId(User.Identity.GetUserId()).
                Select<Reservation, ReservationOutputModel>(g => new ReservationOutputModel(g))
                ));
        }

        /// <summary>
        /// Returns number of free seats for the chosen projection
        /// </summary>
        /// <param name="projectionId">Id of the specific projection</param>
        /// <returns></returns>
        [Route("getFreeSeats/{projectionId}")]
        [ResponseType(typeof(JsonApiOutput<FreeSeatsOutputModel>))]
        [HttpGet]
        public IHttpActionResult GetFreeSeats(int projectionId)
        {
            return Ok(new JsonApiOutput<FreeSeatsOutputModel>(
                new FreeSeatsOutputModel(ReservationsAdapter.QueryProjection(projectionId))
                ));
        }

        /// <summary>
        /// Create a new reservation for the chosen projection
        /// </summary>
        /// <param name="projectionId">Id of the projection for which the user makes the reservation</param>
        /// <returns>the new reservation</returns>
        [Route("add/{projectionId}")]
        [ResponseType(typeof(JsonApiOutput<ReservationOutputModel>))]
        [HttpPost]
        public IHttpActionResult AddNewReservation(int projectionId)
        {
            IEnumerable <Reservation> reservations = ReservationsAdapter.
                QueryReservationsByUserId(User.Identity.GetUserId()).
                Where(r => r.ProjectionId == projectionId);

            if (reservations.Count() != 0)
            {
                return BadRequest("Projection already reserved");
            }

            Reservation reservation = ReservationsAdapter.AddNewReservation(User.Identity.GetUserId(), projectionId);

            return Ok(new JsonApiOutput<ReservationOutputModel>(
                new ReservationOutputModel(reservation)
                ));
        }

        /// <summary>
        /// Complete the reservation process, setting the number of seats reserved
        /// </summary>
        /// <param name="reservationId">Id of the specific reservation to complete</param>
        /// <param name="quantity">Number of seats selected</param>
        /// <returns></returns>
        [Route("complete/{reservationId}/{quantity}")]
        [HttpPut]
        public IHttpActionResult CompleteReservation(int reservationId, int quantity)
        {
            Reservation reservation = ReservationsAdapter.QueryReservation(reservationId);

            if (reservation == null)
            {
                return BadRequest("This reservation does not exist!");
            }

            int freeSeats = reservation.Projection.FreeSeats;

            if (quantity > freeSeats)
            {
                return BadRequest("Number of seats exceeded!");
            }
            
            ReservationsAdapter.CompleteReservation(reservation, quantity);
            return Ok();
        }

        /// <summary>
        /// Cancel the reservation in process or already completed.
        /// In any case, the number of seats for the projection are restored.
        /// </summary>
        /// <param name="reservationId">Id of the spicific reservation to cancel</param>
        /// <returns></returns>
        [Route("cancel/{reservationId}")]
        [HttpDelete]
        public IHttpActionResult CancelReservation(int reservationId)
        {
            Reservation reservation = ReservationsAdapter.QueryReservation(reservationId);

            if (reservation == null)
            {
                return BadRequest("This reservation does not exist!");
            }

            ReservationsAdapter.CancelReservation(reservation);
            return Ok();
        }
       
    }
}
