using api.DAL;
using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.OutputModels
{
    /// <summary>
    /// Contains the information on the cinemas that display the selected movie
    /// </summary>
    public class CinemaMovieProjectionsOutputModel
    {
        private CinemaOutputModel cinema;
        private IEnumerable<ProjectionOutputModel> projections;
        /// <summary>
        /// Creates a new CinemaMovieProjectionsOutputModel from the list of cinemaprojections
        /// </summary>
        /// <param name="cinemaProjections"></param>
        public CinemaMovieProjectionsOutputModel(CinemaProjections cinemaProjections)
        {
            //TODO check this for output consistency
            this.cinema = new CinemaOutputModel(cinemaProjections.Cinema);
            this.projections = cinemaProjections.MovieProjections.Aggregate(
                new MovieProjections(),
                (current, next) => current.addProjections(next.Projections))
                    .Projections.Select<Projection, ProjectionOutputModel>(i => new ProjectionOutputModel(i));
        }
        /// <summary>
        /// Information of the cinema
        /// </summary>
        public CinemaOutputModel Cinema { get { return cinema; } }
        /// <summary>
        /// List of projections of the specific movie
        /// </summary>
        public IEnumerable<ProjectionOutputModel> Projections { get { return projections; } }
        /// <summary>
        /// Imdb of the movie that is projected
        /// </summary>
        public string ImdbId { get; set; }
    }
}