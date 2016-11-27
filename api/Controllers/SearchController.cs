using api.Adapters;
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

namespace api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/v1/Search")]
    public class SearchController : ApiController
    {
        [Route("Cinema")]
        public IEnumerable<CinemaOutputModel> searchByCinema(LocationInputModel input)
        {
            return DatabaseAdapter.queryCinemaByLocation(input.Region, input.Province, input.City, input.MaxRange).Select<Cinema, CinemaOutputModel>(i => new CinemaOutputModel(i));
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("CinemaFromName")]
        [HttpGet]
        public IEnumerable<CinemaOutputModel> searchByCinemaName([FromUri] string name)
        {
            return DatabaseAdapter.queryCinemaByName(name).Select<Cinema, CinemaOutputModel>(i => new CinemaOutputModel(i));
        }
        /// <summary>
        /// return the movies with the title that contains the specified words
        /// </summary>
        /// <param name="title">Title of the movie or part of it (not case sensitive)</param>
        /// <returns></returns>
        [Route("Movie")]
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
        public IEnumerable<MovieOutputModel> searchMoviesFromLocation(LocationInputModel location)
        {
            return DatabaseAdapter.queryMoviesFromLocation(location.Region,location.Province,location.City,location.MaxRange)
                .Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i));
        }

        /// <summary>
        /// Returns the cinemas that display the selected movie, with the projection related to that movie
        /// </summary>
        /// <param name="location"></param>
        /// <param name="imdbid"></param>
        /// <returns></returns>
        [Route("CinemaFromMovie")]
        [HttpGet]
        public IEnumerable<CinemaFromMovieOutputModel> searchCinemasFromMovie([FromUri] LocationInputModel location,[FromUri] string imdbid)
        {
            return DatabaseAdapter.queryCinemaFromMovie(imdbid).Select<CinemaProjection, CinemaFromMovieOutputModel>(i => new CinemaFromMovieOutputModel(i));
        }
    }
}