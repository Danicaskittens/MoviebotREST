using api.Adapters;
using api.DAL;
using api.Models;
using api.Models.Data;
using api.Models.Output;
using api.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using api.DAL;
using Microsoft.AspNet.Identity;

namespace api.Controllers
{
    /// <summary>
    /// Returns recommendations for the user 
    /// </summary>
    [Authorize]
    [RoutePrefix("api/v2/Recommender")]
    public class RecommenderGenreController : ApiController
    {

        /// <summary>
        /// Returns all the recommended movies for the user homepage
        /// </summary>
        [Route("moviesByGenre")]
        [HttpGet]
        public JsonApiOutput<IEnumerable<MovieOutputModel>> GetAllRecommendedMovies()
        {
            return new JsonApiOutput<IEnumerable<MovieOutputModel>>(
                DatabaseAdapter.QueryRecommendedMoviesByGenre(User.Identity.GetUserId()).
                Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i)));
        }

    }
}