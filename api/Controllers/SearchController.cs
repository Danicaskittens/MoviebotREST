using api.Adapters;
using api.Models.Data;
using api.Models.InputModels;
using api.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Search")]
    public class SearchController : ApiController
    {
        [Route("Cinema")]
        public IEnumerable<CinemaOutputModel> searchByCinema(LocationInputModel input)
        {
            return DatabaseAdapter.queryCinemaByLocation(input.Region, input.Province, input.City, input.MaxRange).Select<Cinema, CinemaOutputModel>(i => new CinemaOutputModel(i));
        }

        [Route("CinemaFromName")]
        [HttpGet]
        public IEnumerable<CinemaOutputModel> searchByCinemaName([FromUri] string name)
        {
            return DatabaseAdapter.queryCinemaByName(name).Select<Cinema, CinemaOutputModel>(i => new CinemaOutputModel(i));
        }

        [Route("Movie")]
        [HttpGet]
        public IEnumerable<MovieOutputModel> searchByMovieTitle([FromUri] string title)
        {
            return DatabaseAdapter.queryMoviesByTitle(title).Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i));
        }

        [Route("MovieFromLocation")]
        public IEnumerable<MovieOutputModel> searchByMovieFromLocation(LocationInputModel location)
        {
            return DatabaseAdapter.queryMoviesByLocation(location.Region,location.Province,location.City,location.MaxRange)
                .Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i));
        }

        [Route("CinemaFromMovie")]
        [HttpGet]
        public IEnumerable<CinemaFromMovieOutputModel> searchCinemasFromMovie([FromUri] string imdbid)
        {
            return DatabaseAdapter.queryCinemaFromMovie(imdbid).Select<CinemaProjection, CinemaFromMovieOutputModel>(i => new CinemaFromMovieOutputModel(i));
        }
    }
}