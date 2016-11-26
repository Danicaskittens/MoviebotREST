using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace api.Controllers
{
    [RoutePrefix("api/Recommender")]
    public class RecommenderController : ApiController
    {
        //will be the query result of recommended movies (for now this is a sample)
        RecommendedMovie[] movies = new RecommendedMovie[]
        {
            new RecommendedMovie { Id = 1, Name = "Forrest Gump", Category = "Comedy"},
            new RecommendedMovie { Id = 2, Name = "Titanic", Category = "Drama"},
            new RecommendedMovie { Id = 3, Name = "Avatar", Category = "Sci-Fi"},
            new RecommendedMovie { Id = 4, Name = "The Avengers", Category = "Action"},
            new RecommendedMovie { Id = 5, Name = "The Matrix", Category = "Sci-Fi"},
        };

        //GET api/Recommender/GetAllMovies?userID={userID}
        [Route("GetAllRecommendedMovies")]
        public IEnumerable<RecommendedMovie> GetAllRecommendedMovies(string userID)
        {
            return movies;
        }


    }
}