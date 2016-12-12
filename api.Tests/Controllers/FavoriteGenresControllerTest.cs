using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.DAL;

namespace api.Tests.Controllers
{
    [TestClass]
    public class FavoriteGenresControllerTest
    {
        [TestMethod]
        public void TestCreateNewProfile()
        {
            // Arrange
            FavoriteGenresController controller = new FavoriteGenresController();
            MovieBotContext db = new MovieBotContext();

            // Act
       

            // Assert
        
        }

        [TestMethod]
        public void TestAddGenre()
        {
            // Arrange
            FavoriteGenresController controller = new FavoriteGenresController();

            // Act
            controller.AddFavoriteGenre("Action");

            //Assert


        }

        [TestMethod]
        public void TestRemoveGenre()
        {
            // Arrange
            FavoriteGenresController controller = new FavoriteGenresController();

            // Act
            controller.RemoveFavoriteGenre("Comedy");

            //Assert
        }
    }
}
