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

namespace api.Controllers
{
    [RoutePrefix("api/v1/movies")]
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
            return Ok(new JsonApiOutput<IEnumerable<MovieOutputModel>>(movies.ToList().Select<Movie,MovieOutputModel>(m=>new MovieOutputModel())));
        }

        
    }
}