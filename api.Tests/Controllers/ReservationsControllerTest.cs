using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.Models.OutputModels;
using Moq;
using System.Data.Entity;
using api.DAL;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web;

namespace api.Tests.Controllers
{
    [TestClass]
    public class ReservationsControllerTest
    {
        [TestInitialize]
        public void initialize()
        {
            Utils.setMockContext();
            ReservationsController controller = new ReservationsController();
            //controller.AddNewReservation(23);
        }

        [TestMethod]
        public void freeSeatsReservedTest()
        {
            //TODO mock a reservation process and check the consistency of seats
            Assert.IsTrue(true);
        }
    }
}
