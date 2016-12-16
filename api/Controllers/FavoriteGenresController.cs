using api.Adapters;
using api.DAL;
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
        [Route("getAllCategories")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<Genre>>))]
        [HttpGet]
        public IHttpActionResult GetAllPossibleGenresToChoose()
        {
            return Ok(new JsonApiOutput<IEnumerable<GenreOutputModel>>(
                UserProfileAdapters.QueryAllTypesOfGenre().
                Select<Genre, GenreOutputModel>(g => new GenreOutputModel(g))
                ));
        }

        /// <summary>
        /// Returns all the preferred genres of a user
        /// </summary>
        /// <returns></returns>
        [Route("getByUserId")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<Genre>>))]
        [HttpGet]
        public IHttpActionResult GetAllGenresByUserId()
        {
            IEnumerable<Genre> genres = UserProfileAdapters.QueryGenresByUserId(User.Identity.GetUserId());
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(new JsonApiOutput<IEnumerable<GenreOutputModel>>(
                genres.Select<Genre, GenreOutputModel>(g => new GenreOutputModel(g))
                ));
        }

        /// <summary>
        /// Add a new favorite genre in the user profile
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [Route("add/{genreId}")]
        [HttpPut]
        public IHttpActionResult AddFavoriteGenre(int genreId)
        {
            UserProfileAdapters.AddGenre(User.Identity.GetUserId(), genreId);
            return Ok();
        }

        /// <summary>
        /// Remove one of the favorite genres in the user profile
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [Route("remove/{genreId}")]
        [HttpPut]
        public IHttpActionResult RemoveFavoriteGenre(int genreId)
        {
            UserProfileAdapters.RemoveGenre(User.Identity.GetUserId(), genreId);
            return Ok();
        }
    }
}
