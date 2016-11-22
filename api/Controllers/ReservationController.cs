using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace api.Controllers
{
    [RoutePrefix("api/Reservation")]
    public class ReservationController : ApiController
    {
        //POST api/Reservation/CheckFreeSeats?cinemaId={cinemaId}&movieId={movieId}&projectionTime={projectionTime}
        [Route("CheckFreeSeats")]
        public IHttpActionResult CheckFreeSeats(string cinemaId, string movieId, string projectionTime)
        {
            return Ok();
        }

        //POST api/Reservation/SaveReservation?userId={userId}&cinemaId={cinemaId}&movieId={movieId}&projectionTime={projectionTime}	
        [Route("SaveReservation")]
        public IHttpActionResult SaveReservation(string userId, string cinemaId, string movieId, string projectionTime)
        {
            String timeStamp = GetTimestamp(DateTime.Now);

            Reservation res = new Reservation
            {
                Id = 1,
                cinemaId = cinemaId,
                movieId = movieId,
                projectionTime = projectionTime,
                timeStamp = timeStamp,
                status = "Pending"
            };

            return Ok();
        }

        //POST api/Reservation/SetReservationStatus?reservationId={reservationId}
        [Route("SetReservationStatus")]
        public IHttpActionResult SetReservationStatus(string reservationId)
        {
            //change status from pending to confirmed after payment
            return Ok();
        }

        //utils
        private static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }


    }
}
