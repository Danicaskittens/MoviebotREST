using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api.DAL;
using api.Models.Data;
using api.Adapters;
using api.Models.OutputModels;
using api.Models.Output;
using api.Models.InputModels;

namespace api.Controllers
{
    [RoutePrefix("api/v1/cinemas")]
    public class CinemasController : ApiController
    {
      
        [Route("location/{latitude}/{longitude}/{maxRange}")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<CinemaOutputModel>>))]
        public IHttpActionResult GetCinemasByName(double latitude, double longitude, int maxRange)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByLocation(latitude, longitude, maxRange);
            if (cinemas == null)
            {
                return NotFound();
            }

            return Ok(new JsonApiOutput<IEnumerable<CinemaOutputModel>>(
                    cinemas.Select<Cinema, CinemaOutputModel>(c => new CinemaOutputModel(c)))
                );
        }

        // GET: api/Cinemas/5
        [Route("name/{pattern}")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<CinemaOutputModel>>))]
        public IHttpActionResult GetCinemasByName(string pattern)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaByName(pattern);
            if (cinemas == null)
            {
                return NotFound();
            }

            return Ok(new JsonApiOutput<IEnumerable<CinemaOutputModel>>(
                    cinemas.Select<Cinema, CinemaOutputModel>(c => new CinemaOutputModel(c)))
                );
        }


        /// <summary>
        /// Returns the list of movies that are currently shown in a specific cinema
        /// </summary>
        /// <param name="cinemaId">Id of the cinema whose movies to show</param>
        /// <param name="dateRange">Range of dates</param>
        /// <returns></returns>
        [Route("id/{cinemaId}/movies")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<MovieOutputModel>>))]
        public IHttpActionResult GetMoviesInSpecificCinema(int cinemaId, [FromUri] DateRangeInputModel dateRange)
        {
            Cinema cinema = DatabaseAdapter.queryCinemaByCinemaId(cinemaId);
            return Ok(new JsonApiOutput<IEnumerable<MovieOutputModel>>(
                            DatabaseAdapter.queryMoviesInCinema(cinema,
                                                dateRange.StartDate,
                                                dateRange.EndDate).ToList()
                                    .Select<Movie, MovieOutputModel>(m => new MovieOutputModel(m)).ToList()
                        )
                     );
        }

        

    }
}