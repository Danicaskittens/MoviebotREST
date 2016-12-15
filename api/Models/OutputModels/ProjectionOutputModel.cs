using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.DAL;

namespace api.Models.OutputModels
{
    /// <summary>
    /// Projection information
    /// </summary>
    public class ProjectionOutputModel
    {
        private Projection projection;
        /// <summary>
        /// Don't use this, please, this is only to create the preview of the response
        /// </summary>
        public ProjectionOutputModel()
        {
            this.projection = new Projection();
        }
        /// <summary>
        /// Creates a new projection output model based on a projection object
        /// </summary>
        /// <param name="projection"></param>
        public ProjectionOutputModel(Projection projection)
        {
            this.projection = projection;
        }
        /// <summary>
        /// Imdb of the projected movie
        /// </summary>
        public string ImdbID { get { return this.projection.ImdbId; } }
        /// <summary>
        /// Integer value of the id of the cinema
        /// </summary>
        public int CinemaID { get { return this.projection.CinemaId; } }
        /// <summary>
        /// Date on which the movie is projected in the yyyy-MM-dd format
        /// </summary>
        public string Date { get { return this.projection.Date.ToString("yyyy-MM-dd"); } }
        /// <summary>
        /// Time on which the movie is projected in the HH:mm format
        /// </summary>
        public string Time { get { return this.projection.Date.ToString("HH:mm"); } }

    }
}