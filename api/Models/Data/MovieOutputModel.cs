namespace api.Models.Data
{
    public class MovieOutputModel
    {
        private Movie movie;
        public MovieOutputModel(Movie movie)
        {
            this.movie = movie;
        }
        public string Title { get { return this.movie.Title; } }
        public string ImdbDb { get { return this.movie.ImdbID; } }
    }
}