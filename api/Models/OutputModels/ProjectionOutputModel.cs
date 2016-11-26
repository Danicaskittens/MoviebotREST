using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.OutputModels
{
    public class ProjectionOutputModel
    {
        private Projection projection;
        public ProjectionOutputModel(Projection projection)
        {
            this.projection = projection;
        }
        public string ImdbID { get { return this.projection.ImdbID; } }
        public string CinemaID { get { return this.projection.CinemaID; } }
        public string Date { get { return this.projection.Date.ToString("yyyy/MM/dd"); } }
        public string Time { get { return this.projection.Date.ToString("HH:mm"); } }

    }
}