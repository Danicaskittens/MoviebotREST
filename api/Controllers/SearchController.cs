using api.Adapters;
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
        public List<CinemaOutputModel> searchByCinema(CinemaInputModel input)
        {
            return DatabaseAdapter.queryCinemaByLocation(input.Region, input.Province, input.City, input.MaxRange);
        }

        [Route("CinemaByName")]
        public List<CinemaOutputModel> searchByCinemaName(string name)
        {
            return DatabaseAdapter.queryCinemaByName(name);
        }




    }