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
using System.Web.Http.Cors;

namespace api.Controllers
{
    /// <summary>
    /// This controller handles every call for cinema related apis
    /// </summary>
    [RoutePrefix("api/v2/cinemas")]
    public class CinemasController : ApiController
    {
        /// <summary>
        /// Returns the list of cinemas near the provided gps locations
        /// </summary>
        /// <param name="latitude">latitude of the center of the search radius</param>
        /// <param name="longitude">longitude of the center of the search radius</param>
        /// <param name="maxRange">maximum radius of the search area (in kilometers)</param>
        /// <returns></returns>
        [Route("location/{latitude}/{longitude}")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<CinemaOutputModel>>))]
        public IHttpActionResult GetCinemasByName(double latitude, double longitude, [FromUri] int maxRange = 50)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.QueryCinemaByLocation(latitude, longitude, maxRange);
            if (cinemas == null)
            {
                return NotFound();
            }

            return Ok(new JsonApiOutput<IEnumerable<CinemaOutputModel>>(
                    cinemas.Select<Cinema, CinemaOutputModel>(c => new CinemaOutputModel(c)))
                );
        }

        /// <summary>
        /// Returns the list of cinemas with the provided name or part of the name
        /// </summary>
        /// <param name="pattern">Complete name or part of the name (case insensitive)</param>
        /// <returns></returns>
        [Route("name/{pattern}")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<CinemaOutputModel>>))]
        public IHttpActionResult GetCinemasByName(string pattern)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.QueryCinemaByName(pattern);
            if (cinemas == null)
            {
                return NotFound();
            }

            return Ok(new JsonApiOutput<IEnumerable<CinemaOutputModel>>(
                    cinemas.Select<Cinema, CinemaOutputModel>(c => new CinemaOutputModel(c)))
                );
        }

        /// <summary>
        /// Returns the list of cinemas with the provided name or part of the name but near a specified location
        /// </summary>
        /// <param name="pattern">Complete name or part of the name (case insensitive)</param>
        /// <param name="latitude">latitude of the center of the search radius</param>
        /// <param name="longitude">longitude of the center of the search radius</param>
        /// <param name="maxRange">maximum radius of the search area (in kilometers)</param>
        /// <returns></returns>
        [Route("name/{pattern}/{latitude}/{longitude}")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<CinemaOutputModel>>))]
        public IHttpActionResult GetCinemasByName(string pattern, double latitude, double longitude, [FromUri] int maxRange = 50)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.QueryCinemaByNameAndLocation(pattern,latitude,longitude,maxRange);
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
            Cinema cinema = DatabaseAdapter.QueryCinemaByCinemaId(cinemaId);
            return Ok(new JsonApiOutput<IEnumerable<MovieOutputModel>>(
                            DatabaseAdapter.QueryMoviesInCinema(cinema,
                                                dateRange.StartDate,
                                                dateRange.EndDate).ToList()
                                    .Select<Movie, MovieOutputModel>(m => new MovieOutputModel(m)).ToList()
                        )
                     );
        }



    }
}