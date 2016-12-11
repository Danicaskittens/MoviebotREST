using api.DAL;
using api.Models.Data;
using api.Models.OutputModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace api.Controllers
{
    [Authorize]
    [RoutePrefix("api/v2/FavoriteGenres")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FavoriteGenresController : ApiController
    {
        private MovieBotContext db = new MovieBotContext();

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
        /// Create a new user profile (empty)
        /// </summary>
        /// <returns>BadRequest if the profile already exists, ok otherwise</returns>
        [Route("createNewProfile")]
        [HttpPost]
        public IHttpActionResult CreateNewUserProfile()
        {
            FavoriteGenres profile = db.FavoriteGenres.Find(User.Identity.GetUserId());
            if (profile != null)
            {
                return BadRequest();
            }

            FavoriteGenres newProfile = new FavoriteGenres();
            newProfile.UserId = User.Identity.GetUserId();
            db.FavoriteGenres.Add(newProfile);
            db.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Add a new favorite genre in the user profile
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [Route("addFavoriteGenre/{genre}")]
        [HttpPut]
        public IHttpActionResult AddFavoriteGenre(string genre)
        {
            FavoriteGenres profile = db.FavoriteGenres.Find(User.Identity.GetUserId());
            if (profile == null)
            {
                return NotFound();
            }
            profile.Genres.Add((Genre)Enum.Parse(typeof(Genre), genre));
            db.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Remove one of the favorite genres in the user profile
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [Route("removeFavoriteGenre/{genre}")]
        [HttpPut]
        public IHttpActionResult RemoveFavoriteGenre(string genre)
        {
            FavoriteGenres profile = db.FavoriteGenres.Find(User.Identity.GetUserId());
            if (profile == null)
            {
                return NotFound();
            }
            profile.Genres.Remove((Genre)Enum.Parse(typeof(Genre), genre));
            db.SaveChanges();
            return Ok();
        }








    }
}
