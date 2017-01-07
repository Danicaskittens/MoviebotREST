using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.Models.OutputModels;
using api.Models.Output;
using System.Collections.Generic;
using System.Data.Entity;
using Moq;
using api.DAL;
using System.Linq;
using api.Adapters;
using api.Models.Data;

namespace api.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTest
    {
       
        [TestInitialize]
        public void initialize()
        {
            Utils.setMockContext(); 
        }

        [TestMethod]
        public void getMovieByTitleTest()
        {
            MoviesController controller = new MoviesController();
            var result = controller.GetMovieByTitle("itanic") as System.Web.Http.Results.OkNegotiatedContentResult<JsonApiOutput<IEnumerable<MovieOutputModel>>>;
            IEnumerable<MovieOutputModel> moviesList = result.Content.Data;
            foreach (var item in moviesList)
            {
                if (item.Title.Contains("itanic"))
                {
                    Assert.IsTrue(true);
                    return;
                }
            }
            Assert.Fail();
        }

        [TestMethod]
        public void getMovieFromLocationTest()
        {
            MoviesController controller = new MoviesController();
            var result = controller.GetMoviesFromLocationAndDateRange(45,9,new Models.InputModels.DateRangeInputModel() { StartDate=DateTime.MinValue,EndDate=DateTime.MaxValue},5000) as System.Web.Http.Results.OkNegotiatedContentResult<JsonApiOutput<IEnumerable<MovieOutputModel>>>;
            IEnumerable<MovieOutputModel> moviesList = result.Content.Data;
            foreach (var item in moviesList)
            {
                if (item.Title.ToLower().Contains("gump"))
                {
                    Assert.IsTrue(true);
                    return;
                }
            }
            Assert.Fail();
        }
    }
}
