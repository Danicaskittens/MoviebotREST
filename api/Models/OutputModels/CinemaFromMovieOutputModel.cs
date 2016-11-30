using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.OutputModels
{
    public class CinemaFromMovieOutputModel
    {
        private CinemaOutputModel cinema;
        private IEnumerable<ProjectionOutputModel> projections;
        public CinemaFromMovieOutputModel(CinemaProjections cinemaProjections)
        {
            //TODO check this for output consistency
            this.cinema = new CinemaOutputModel(cinemaProjections.Cinema);
            this.projections = cinemaProjections.MovieProjections.Aggregate(
                new MovieProjections(),
                (current, next) => current.addProjections(next.Projections))
                    .Projections.Select<Projection, ProjectionOutputModel>(i => new ProjectionOutputModel(i));
        }
        public CinemaOutputModel Cinema { get { return cinema; } }
        public IEnumerable<ProjectionOutputModel> Projections { get { return projections; } }
        public string ImdbId { get; set; }
    }
}