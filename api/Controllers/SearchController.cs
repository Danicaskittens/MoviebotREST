using api.Adapters;
using api.DAL;
using api.Models.Data;
using api.Models.InputModels;
using api.Models.Output;
using api.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api.Controllers
{
    /// <summary>
    /// This controller is the one that provides the search related endpoints
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/v1/Search")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {

        /// <summary>
        /// Returns every cinema that is located near the provided coordinates
        /// </summary>
        /// <param name="location">Location information</param>
        /// <returns></returns>
        [Route("CinemaFromLocation")]
        [HttpGet]
        public JsonApiOutput<IEnumerable<CinemaOutputModel>> searchCinemaByLocation([FromUri] LocationInputModel location)
        {
            return
                new JsonApiOutput<IEnumerable<CinemaOutputModel>>(
                    DatabaseAdapter.queryCinemaByLocation(location.Latitude, location.Longitude, location.MaxRange)
                    .Select<Cinema, CinemaOutputModel>(i => new CinemaOutputModel(i))
                    );
        }

        /// <summary>
        ///  Returns the list of cinemas that contains the provided pattern in the name
        /// </summary>
        /// <param name="pattern">search pattern to search for in the cinema names</param>
        /// <returns></returns>
        [Route("CinemaFromName")]
        [HttpGet]
        public JsonApiOutput<IEnumerable<CinemaOutputModel>> searchByCinemaName([FromUri] string pattern)
        {
            return
                new JsonApiOutput<IEnumerable<CinemaOutputModel>>(
                    DatabaseAdapter.queryCinemaByName(pattern).Select<Cinema, CinemaOutputModel>(i => new CinemaOutputModel(i))
                    );
        }

        /// <summary>
        /// return the movies with the title that contains the specified words
        /// </summary>
        /// <param name="title">Title of the movie or part of it (not case sensitive)</param>
        /// <returns></returns>
        [Route("MovieFromTitle")]
        [HttpGet]
        public JsonApiOutput<IEnumerable<MovieOutputModel>> searchByMovieTitle([FromUri] string title)
        {
            return new JsonApiOutput<IEnumerable<MovieOutputModel>>(DatabaseAdapter.queryMoviesByTitle(title).Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i)));
        }

        /// <summary>
        /// Return all the movies in every cinema near the location provided
        /// </summary>
        /// <param name="location">Location from where to find the cinemas and movies</param>
        /// <returns></returns>
        [Route("MovieFromLocation")]
        public JsonApiOutput<IEnumerable<MovieOutputModel>> searchMoviesFromLocation([FromUri] LocationInputModel location)
        {
            return
                new JsonApiOutput<IEnumerable<MovieOutputModel>>(
                    DatabaseAdapter.queryMoviesFromLocation(location.Latitude, location.Longitude, location.MaxRange)
                        .Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i))
                );
        }

        /// <summary>
        /// Returns the cinemas that display the selected movie, with the projection related to that movie
        /// </summary>
        /// <param name="location">location from which search the available movies</param>
        /// <param name="imdbid">movie id to search for</param>
        /// <returns></returns>
        [Route("CinemaFromMovie")]
        [HttpGet]
        public JsonApiOutput<IEnumerable<CinemaMovieProjectionsOutputModel>> searchCinemasFromMovie([FromUri] LocationInputModel location, [FromUri] string imdbid)
        {
            return new JsonApiOutput<IEnumerable<CinemaMovieProjectionsOutputModel>>(
                DatabaseAdapter.queryCinemaFromMovie(location.Latitude, location.Longitude, location.MaxRange, imdbid)
                .Select<CinemaProjections, CinemaMovieProjectionsOutputModel>(i => new CinemaMovieProjectionsOutputModel(i)));
        }
    }
}