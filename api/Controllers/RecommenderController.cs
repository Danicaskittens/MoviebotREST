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

namespace api.Controllers
{   
    [RoutePrefix("api/v1/Recommender")]
    public class RecommenderController : ApiController
    {
        private static List<Movie> getRecommendedMovies()
        {
            Movie movie1 = new Movie()
            {
                Title = "Forrest Gump",
                imdbID = "tt0838881",
                Genre = "Comedy"
            };
            Movie movie2 = new Movie()
            {
                Title = "Titanic",
                imdbID = "tt2393120",
                Genre = "Drama"
            };
            Movie movie3 = new Movie()
            {
                Title = "Avatar",
                imdbID = "tt1032612",
                Genre = "Sci-Fi"
            };
            Movie movie4 = new Movie()
            {
                Title = "The Avengers",
                imdbID = "tt1928374",
                Genre = "Action"
            };
            Movie movie5 = new Movie()
            {
                Title = "The Matrix",
                imdbID = "tt0099362",
                Genre = "Sci-Fi"
            };

            return new List<Movie>() { movie1, movie2, movie3 };
        }
      
 
        /// <summary>
        /// return all the recommended movies for the user homepage
        /// </summary>
        [Route("GetAllRecommendedMovies")]
        [HttpGet]
        public JsonApiOutput<IEnumerable<MovieOutputModel>> GetAllRecommendedMovies()
        {
            return new JsonApiOutput<IEnumerable<MovieOutputModel>>(getRecommendedMovies().
                Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i)));
        }

    }
}