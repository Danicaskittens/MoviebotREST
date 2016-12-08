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
using api.Models.InputModels;
using System.Web.Http.Cors;

namespace api.Controllers
{
    /// <summary>
    /// This controller enables the retrieval of projections related information
    /// </summary>
    [RoutePrefix("api/v2/projections")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectionsController : ApiController
    {
        /// <summary>
        /// Returns the projection with the specified projection id
        /// </summary>
        /// <param name="projectionId">Id of the projection to retrieve</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the list of projections of a specified cinema, imdbId and date range
        /// </summary>
        /// <param name="cinemaId">Id of the cinema to search the projections from</param>
        /// <param name="imdbId">Id of the movie to search the projections of</param>
        /// <param name="dateRange">Range of dates into which search the projections</param>
        /// <returns></returns>
        [Route("list/{cinemaId}/{imdbId}")]
        [ResponseType(typeof(JsonApiOutput<IEnumerable<ProjectionOutputModel>>))]
        public IHttpActionResult getProjectionsByCinemaAndImdbId(int cinemaId, string imdbId, [FromUri] DateRangeInputModel dateRange)
        {
            IQueryable<Projection> projections = DatabaseAdapter.queryProjectionsByCinemaAndMovieAndDateRange(cinemaId, imdbId, dateRange.StartDate, dateRange.EndDate);
            return Ok(new JsonApiOutput<IEnumerable<ProjectionOutputModel>>(
                            projections.ToList().Select<Projection, ProjectionOutputModel>(p => new ProjectionOutputModel(p))
                            )
                      );
        }

        /// <summary>
        /// Retrieves the list of projections of an imdbId and date range for a list of cinema ids
        /// </summary>
        /// <param name="imdbId">Id of the movie to retrieve the projections of</param>
        /// <param name="cinemaIds">Array of cinema ids added as body of the request and Content-Type: application/json in the header </param>
        /// <param name="dateRange">Range of dates on which to search the projections</param>
        /// <returns></returns>
        [HttpPost]
        [Route("clist/{imdbId}")]
        [ResponseType(typeof(JsonApiOutput<Dictionary<int, IEnumerable<ProjectionOutputModel>>>))]
        public IHttpActionResult getProjectionsOfMultipleCinemasForSameImdbId(string imdbId,[FromBody] List<int> cinemaIds,[FromUri] DateRangeInputModel dateRange)
        {

            Dictionary<int, IEnumerable<ProjectionOutputModel>> result =
                cinemaIds.Aggregate<int,Dictionary<int, IEnumerable<ProjectionOutputModel>>>(new Dictionary<int, IEnumerable<ProjectionOutputModel>>(),
                            (current, next) =>
                            {
                                var cinemaProjections = DatabaseAdapter.queryProjectionsByCinemaAndMovieAndDateRange(next, imdbId, dateRange.StartDate, dateRange.EndDate);
                                current[next] = cinemaProjections.ToList().Select(p => new ProjectionOutputModel(p));
                                return current;
                            });
            return Ok(new JsonApiOutput<Dictionary<int, IEnumerable<ProjectionOutputModel>>>(result));

        }

        /// <summary>
        /// Retrieves the list of the projections of multiple imdbids on the same cinema on a specified date range
        /// </summary>
        /// <param name="cinemaId"></param>
        /// <param name="imdbIds"></param>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("mlist/{cinemaId}")]
        [ResponseType(typeof(JsonApiOutput<Dictionary<string, IEnumerable<ProjectionOutputModel>>>))]
        public IHttpActionResult getProjectionsOfMultipleImdbsForSameCinemaId(int cinemaId, [FromBody] List<string> imdbIds, [FromUri] DateRangeInputModel dateRange)
        {
            Dictionary<string, IEnumerable<ProjectionOutputModel>> result =
                imdbIds.Aggregate<string, Dictionary<string, IEnumerable<ProjectionOutputModel>>>(new Dictionary<string, IEnumerable<ProjectionOutputModel>>(),
                            (current, next) =>
                            {
                                var cinemaProjections = DatabaseAdapter.queryProjectionsByCinemaAndMovieAndDateRange(cinemaId, next, dateRange.StartDate, dateRange.EndDate);
                                current[next] = cinemaProjections.ToList().Select(p => new ProjectionOutputModel(p));
                                return current;
                            });
            return Ok(new JsonApiOutput<Dictionary<string, IEnumerable<ProjectionOutputModel>>>(result));
        }
    }
}