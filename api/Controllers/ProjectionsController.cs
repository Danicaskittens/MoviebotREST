using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api.DAL;
using api.Models.Data;
using api.Models.OutputModels;
using api.Adapters;

namespace api.Controllers
{
    /// <summary>
    /// This controller enables the retrieval of projections related information
    /// </summary>
    [RoutePrefix("api/v2/projections")]
    public class ProjectionsController : ApiController
    {
        [Route("id/{projectionId}")]
        [ResponseType(typeof(JsonApiOutput<ProjectionOutputModel>))]
        public IHttpActionResult getProjectionById(int projectionId)
        {
            Projection projection = DatabaseAdapter.queryProjectionByProjectionId(projectionId);
            if (projection == null)
            {
                return NotFound();
            }
            return Ok(new JsonApiOutput<ProjectionOutputModel>(new ProjectionOutputModel(projection)));
        }

    }
}