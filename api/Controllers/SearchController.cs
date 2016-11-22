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
        public IEnumerable<CinemaOutputModel> searchByCinema(CinemaInputModel input)
        {
            return DatabaseAdapter.queryCinemaByLocation(input.Region, input.Province, input.City, input.MaxRange).Select<Cinema, CinemaOutputModel>(i => new CinemaOutputModel(i));
        }

        [Route("CinemaByName")]
        public IEnumerable<CinemaOutputModel> searchByCinemaName(string name)
        {
            return DatabaseAdapter.queryCinemaByName(name).Select<Cinema, CinemaOutputModel>(i => new CinemaOutputModel(i));
        }

        [Route("Movie")]
        public IEnumerable<MovieOutputModel> searchByMovieTitle(string title)
        {
            return DatabaseAdapter.queryMoviesByTitle(title).Select<Movie, MovieOutputModel>(i => new MovieOutputModel(i));
        }

    }
}