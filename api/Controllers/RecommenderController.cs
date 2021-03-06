﻿using api.Adapters;
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

namespace api.Controllers
{
    /// <summary>
    /// Returns recommendations for the user 
    /// </summary>
    [RoutePrefix("api/v1/Recommender")]
    public class RecommenderController : ApiController
    {

        /// <summary>
        /// Returns all the recommended movies for the user homepage
        /// </summary>
        [Route("movies")]
        [HttpGet]
        public JsonApiOutput<IEnumerable<MovieOutputModel>> GetAllRecommendedMovies()
        {
            return new JsonApiOutput<IEnumerable<MovieOutputModel>>(
                DatabaseAdapter.QueryRecommendedMoviesForUser("placeholder").
                Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i)));
        }

    }
}