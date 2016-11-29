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
        public CinemaFromMovieOutputModel(CinemaProjection cinemaProjection)
        {
            this.cinema = new CinemaOutputModel(cinemaProjection.Cinema);
            this.ImdbId = cinemaProjection.Movie.ImdbId;
            this.projections = cinemaProjection.Projections.Select<Projection, ProjectionOutputModel>(i => new ProjectionOutputModel(i));
        }
        public CinemaOutputModel Cinema { get { return cinema; } }
        public IEnumerable<ProjectionOutputModel> Projections { get { return projections; } }
        public string ImdbId { get; set; }
    }
}