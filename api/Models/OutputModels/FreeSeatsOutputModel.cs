using api.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.OutputModels
{
    /// <summary>
    /// Free seats info
    /// </summary>
    public class FreeSeatsOutputModel
    {
       
        private Projection projection;

        /// <summary>
        /// Don't use this, please, this is only to create the preview of the response
        /// </summary>
        public FreeSeatsOutputModel()
        {
            projection = new Projection();
        }
        /// <summary>
        /// Create a new free seats output model based on a specific projection
        /// </summary>
        /// <param name="cinema"></param>
        public FreeSeatsOutputModel(Projection projection)
        {
            this.projection = projection;
        }
        /// <summary>
        /// Id of the projection
        /// </summary>
        public int ProjectionId { get { return this.projection.ProjectionId; } }
        /// <summary>
        /// Number of free seats
        /// </summary>
        public int FreeSeats { get { return this.projection.FreeSeats; } }


    }
}