using api.DAL;
using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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
using api.Models.OutputModels;
using api.Adapters;
using api.Models.InputModels;
using System.Web.Http.Cors;
using System.Diagnostics;

namespace api.Adapters
{
    /// <summary>
    /// This adapter contains every function regarding the user profile management
    /// </summary>
    public class UserProfileAdapters
    {
        private static MovieBotContext context = new MovieBotContext();

        /// <summary>
        /// Returns the list of all the types of genre
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Genre> QueryAllTypesOfGenre()
        {
            return context.Genres;
        }

        /// <summary>
        /// Returns the list of preferred genres associated to a user
        /// </summary>
        /// <param name="userId">id of the user from whose profile is removing the genre</param>
        /// <returns></returns>
        public static IEnumerable<Genre> QueryGenresByUserId(string userId)
        {
            FavoriteGenres profile = RetrieveGenresFavorites(userId);
            return profile.Genres;
        }

        /// <summary>
        /// Adds a genre to the list of preferred genres associated to
        /// a user
        /// </summary>
        /// <param name="userId">id of the user on whose profile is adding the genre</param>
        /// <param name="genreId"> id of the genre to add</param>
        public static void AddGenre(string userId, int genreId)
        {
            FavoriteGenres profile = RetrieveGenresFavorites(userId);

            if (profile.Genres == null)
            {
                profile.Genres = new List<Genre>();
            }

            Genre genre = context.Genres.Find(genreId);
            if (genre != null)
            {
                if (!profile.Genres.Contains(genre))
                {
                    profile.Genres.Add(genre);
                }
            }

            context.SaveChanges();
        }


        /// <summary>
        /// Remove a genre from the list of preferred genres associated 
        /// to a user
        /// </summary>
        /// <param name="userId">id of the user from whose profile is removing the genre</param>
        /// <param name="genreId">id of the genre to remove</param>
        public static void RemoveGenre(string userId, int genreId)
        {
            FavoriteGenres profile = RetrieveGenresFavorites(userId);

            if (profile.Genres == null)
            {
                profile.Genres = new List<Genre>();
            }

            Genre genre = context.Genres.Find(genreId);
            if (genre != null)
            {
                if (profile.Genres.Contains(genre))
                {
                    profile.Genres.Remove(genre);
                }
            }

            context.SaveChanges();

        }

        /// <summary>
        /// Retrieves the user favorite genres list from the database, creating a new one
        /// if it's not present
        /// </summary>
        /// <param name="userId">id of the user of the favorites profile to retrieve/generate</param>
        /// <returns>the selected user profile from the database or a new one if not present</returns>
        private static FavoriteGenres RetrieveGenresFavorites(string userId)
        {
            FavoriteGenres profile = context.FavoriteGenres.Find(userId);
            if (profile == null)
            {
                FavoriteGenres newProfile = new FavoriteGenres();
                newProfile.UserId = userId;
                context.FavoriteGenres.Add(newProfile);
                context.SaveChanges();
                return newProfile;
            }
            return profile;
        }

    }
}