using api.DAL;
using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Adapters
{
    /// <summary>
    /// This adapter contains every function regarding the user profile management
    /// </summary>
    public class UserProfileAdapters
    {
        private static MovieBotContext context = new MovieBotContext();


        /// <summary>
        /// Adds a genre to the list of preferred genres associated to
        /// a user
        /// </summary>
        /// <param name="userId">id of the user on whose profile is adding the genre</param>
        /// <param name="genre">name of the genre to add</param>
        public static void addGenre(string userId, string genre)
        {
            FavoriteGenres profile = retrieveGenresFavorites(userId);
            profile.Genres.Add((Genre)Enum.Parse(typeof(Genre), genre));
            context.SaveChanges();
        }

        /// <summary>
        /// Remove a genre from the list of preferred genres associated 
        /// to a user
        /// </summary>
        /// <param name="userId">id of the user from whose profile is removing the genre</param>
        /// <param name="genre">name of the genre to remove</param>
        public static void removeGenre(string userId, string genre)
        {
            FavoriteGenres profile = retrieveGenresFavorites(userId);
            profile.Genres.Add((Genre)Enum.Parse(typeof(Genre), genre));
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves the user favorite genres list from the database, creating a new one
        /// if it's not present
        /// </summary>
        /// <param name="userId">id of the user of the favorites profile to retrieve/generate</param>
        /// <returns>the selected user profile from the database or a new one if not present</returns>
        private static FavoriteGenres retrieveGenresFavorites(string userId)
        {
            FavoriteGenres profile = context.FavoriteGenres.Find(userId);
            if (profile != null)
            {
                return profile;
            }
            FavoriteGenres newProfile = new FavoriteGenres();
            newProfile.UserId = userId;
            context.FavoriteGenres.Add(newProfile);
            context.SaveChanges();
            return newProfile;
        }
        

    }
}