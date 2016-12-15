using api.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.OutputModels
{
    /// <summary>
    /// Genre information
    /// </summary>
    public class GenreOutputModel
    {
        private Genre genre;

        /// <summary>
        /// Don't use this, please, this is only to create the preview of the response
        /// </summary>
        public GenreOutputModel()
        {
            genre = new Genre();
        }
        /// <summary>
        /// Create a new genre output model based on a specific genre
        /// </summary>
        /// <param name="cinema"></param>
        public GenreOutputModel(Genre genre)
        {
            this.genre = genre;
        }
        /// <summary>
        /// Id of the genre
        /// </summary>
        public int GenreId { get { return this.genre.GenreId; } }
        /// <summary>
        /// Name of the genre
        /// </summary>
        public string Name { get { return this.genre.Name; } }
    }
}