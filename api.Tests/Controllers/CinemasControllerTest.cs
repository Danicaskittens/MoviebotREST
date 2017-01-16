using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.Models.OutputModels;
using System.Collections.Generic;

namespace api.Tests.Controllers
{
    [TestClass]
    public class CinemasControllerTest
    {
        [TestInitialize]
        public void initialize()
        {
            Utils.setMockContext();
        }

        [TestMethod]
        public void getCinemasByNameTest()
        {
            CinemasController controller = new CinemasController();
            var result = controller.GetCinemasByName("targa") as System.Web.Http.Results.OkNegotiatedContentResult<JsonApiOutput<IEnumerable<CinemaOutputModel>>>;
            IEnumerable<CinemaOutputModel> cinemasList = result.Content.Data;
            foreach (var item in cinemasList)
            {
                if (item.Name.Contains("targa"))
                {
                    Assert.IsTrue(true);
                    return;
                }
            }
            Assert.Fail();
        }

    }
}
