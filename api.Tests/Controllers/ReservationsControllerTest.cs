using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.Models.OutputModels;

namespace api.Tests.Controllers
{
    [TestClass]
    public class ReservationsControllerTest
    {

        [TestInitialize]
        public void initialize()
        {
            Utils.setMockContext();
        }

        [TestMethod]
        public void freeSeatsReservedTest()
        {
            ReservationsController controller = new ReservationsController();
            //TODO mock a reservation process and check the consistency of seats
            Assert.IsTrue(true);
        }
    }
}
