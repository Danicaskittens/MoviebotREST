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
using api.Models.Output;
using api.Models.OutputModels;
using api.Models.InputModels;
using System.Web.Http.Cors;

namespace api.Controllers
{
    /// <summary>
    /// This controllers enables the retrieval of movie related information
    /// </summary>
    [RoutePrefix("api/v2/movies")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MoviesController : ApiController
    {
        /// <summary>
        /// Returns the list of movies with the title provided or part of the title
        /// </summary>
        /// <param name="title">Title of the movie or part of the title</param>
        /// <returns></returns>
        [Route("title/{title}")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<MovieOutputModel>>))]
        public IHttpActionResult GetMovieByTitle(string title)
        {
            IQueryable<Movie> movies = DatabaseAdapter.queryMoviesByTitle(title);
            return Ok(new JsonApiOutput<IEnumerable<MovieOutputModel>>(movies.ToList().Select<Movie, MovieOutputModel>(m => new MovieOutputModel(m))));
        }


        /// <summary>
        /// Retrieves the list of cinemas near a location and that display a specific movie in a specified date range 
        /// </summary>
        /// <param name="imdbId">imdbId of the movie to search</param>
        /// <param name="latitude">latitude of the center of the search radius</param>
        /// <param name="longitude">longitude of the center of the search radius</param>
        /// <param name="maxRange">maximum radius of the search area (in kilometers)</param>
        /// <param name="dateRange">range of dates on which search for cinemas that display the movie, if omitted, today's date will be used</param>
        /// <returns></returns>
        [Route("id/{imdbId}/cinemas/{latitude}/{longitude}")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<CinemaOutputModel>>))]
        public IHttpActionResult GetCinemasByMovieAndLocationAndDateRange(string imdbId, double latitude, double longitude, [FromUri] DateRangeInputModel dateRange, [FromUri] int maxRange = 50)
        {
            IEnumerable<Cinema> cinemas = DatabaseAdapter.queryCinemaFromMovie(latitude, longitude, maxRange, imdbId, dateRange.StartDate, dateRange.EndDate).ToList();
            return Ok(new JsonApiOutput<IEnumerable<CinemaOutputModel>>(
                        cinemas.ToList().Select<Cinema, CinemaOutputModel>(c => new CinemaOutputModel(c)).ToList()
                    ));
        }


    }
}