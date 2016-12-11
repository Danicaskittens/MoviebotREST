using api.Adapters;
using api.Models.Data;
using api.Models.OutputModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace api.Controllers
{
    /// <summary>
    /// Favorites genre management for the user
    /// </summary>
    [Authorize]
    [RoutePrefix("api/v2/FavoriteGenres")]
    public class FavoriteGenresController : ApiController
    {        

        /// <summary>
        /// Returns all the possible genres that a user can choose
        /// </summary>
        /// <returns></returns>
        [Route("getAll")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<Genre>>))]
        [HttpGet]
        public IHttpActionResult GetAllPossibleGenresToChoose()
        {
            return Ok(new JsonApiOutput<IEnumerable<Genre>>(
                Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList()
                ));
        }

        /// <summary>
        /// Add a new favorite genre in the user profile
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [Route("add/{genre}")]
        [HttpPut]
        public IHttpActionResult AddFavoriteGenre(string genre)
        {
            UserProfileAdapters.addGenre(User.Identity.GetUserId(), genre);
            return Ok();
        }

        /// <summary>
        /// Remove one of the favorite genres in the user profile
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [Route("remove/{genre}")]
        [HttpPut]
        public IHttpActionResult RemoveFavoriteGenre(string genre)
        {
            UserProfileAdapters.removeGenre(User.Identity.GetUserId(), genre);
            return Ok();
        }








    }
}
