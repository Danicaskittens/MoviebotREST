using api.Models.Data;
using api.DAL;

namespace api.Models.Output
{
    /// <summary>
    /// Contains the information of a specific movie
    /// </summary>
    public class MovieOutputModel
    {
        private Movie movie;
        /// <summary>
        /// Don't use this, please, this is only to create the preview of the response
        /// </summary>
        public MovieOutputModel()
        {
            this.movie = new Movie();
        }

        /// <summary>
        /// Create a new Movie output model from a Movie data object
        /// </summary>
        /// <param name="movie"></param>
        public MovieOutputModel(Movie movie)
        {
            this.movie = movie;
        }
        /// <summary>
        /// Title of the movie
        /// </summary>
        public string Title { get { return this.movie.Title; } }
        /// <summary>
        /// ImdbID of the movie
        /// </summary>
        public string ImdbID { get { return this.movie.ImdbId; } }
        /// <summary>
        /// URI of the poster image of the movie
        /// </summary>
        public string Poster { get { return this.movie.Poster; } }
        /// <summary>
        /// Runtime length of the movie (es. 143 min)
        /// </summary>
        public string Runtime { get { return this.movie.Runtime; } }
        /// <summary>
        /// Short plot description of the movie
        /// </summary>
        public string Plot { get { return this.movie.Plot; } }
        /// <summary>
        /// List of genres of the movie
        /// </summary>
        public string Genre { get { return this.movie.Genre; } }
        /// <summary>
        /// Imdb rating value
        /// </summary>
        public string imdbRating { get { return this.movie.imdbRating; } }
        /// <summary>
        /// Imdb votes 
        /// </summary>
        public string imdbVotes { get { return this.movie.imdbVotes; } }
        /// <summary>
        /// Response of the movie goers
        /// </summary>
        public string Response { get { return this.movie.Response; } }
        /// <summary>
        /// Movie director
        /// </summary>
        public string Director { get { return this.movie.Director; } }
        /// <summary>
        /// movie actors
        /// </summary>
        public string Actors { get { return this.movie.Actors; } }
        /// <summary>
        /// metascore value
        /// </summary>
        public string Metascore { get { return this.movie.Metascore; } }
        /// <summary>
        /// list of awards
        /// </summary>
        public string Awards { get { return this.movie.Awards; } }


    }
}