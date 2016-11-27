using api.Adapters;
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
    /// <summary>
    /// This endpoint proxies requests to the omdb apis
    /// </summary>
    [RoutePrefix("api/v1/omdb")]
    public class OmdbProxyController : ApiController
    {
        /// <summary>
        /// Returns the movie information from omdb for the specified imdbID
        /// </summary>
        /// <param name="imdbID">Imdb id of the movie to retrieve the info</param>
        /// <returns> The movie information </returns>
        [Route("movie")]
        public JsonApiOutput<MovieOutputModel> GetMovieInfo(string imdbID)
        {
            return new JsonApiOutput<MovieOutputModel>(new MovieOutputModel(OmdbAdapters.GetMovieInfo(imdbID)));
        }
    }
}
