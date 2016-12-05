using api.DAL;
using api.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class TestDataController : ApiController
    {
        private CinemaInterfaceServerModelContainer db = new CinemaInterfaceServerModelContainer();

        [HttpGet]
        public JsonApiOutput<String> AddTestMovies()
        {
            MovieBotInitializer initializer = new MovieBotInitializer();
            initializer.InitializeDatabase(db);
            return new JsonApiOutput<string>("bom tutto a posto");
        }
    }
}
