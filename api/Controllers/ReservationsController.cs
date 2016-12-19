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
        /// <returns></returns>
        [Route("add/{projectionId}")]
        [HttpPost]
        public IHttpActionResult AddNewReservation(int projectionId)
        {
            ReservationsAdapter.AddNewReservation(User.Identity.GetUserId(), projectionId);
            return Ok();
        }

        /// <summary>
        /// Set number of seats for the specific reservation
        /// and update reservation to "complete"
        /// </summary>
        /// <param name="reservationId">Id of the specific reservation</param>
        /// <param name="quantity">Number of seats selected</param>
        /// <returns></returns>
        [Route("complete/{reservationId}/{quantity}")]
        [HttpPut]
        public IHttpActionResult CompleteReservation(int reservationId, int quantity)
        {
            ReservationsAdapter.CompleteReservation(reservationId, quantity);
            return Ok();
        }
       
    }
}
