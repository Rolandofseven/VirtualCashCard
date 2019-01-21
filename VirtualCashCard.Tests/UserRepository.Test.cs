using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualCashCard.Models;
using VirtualCashCard.Services;

namespace VirtualCashCard.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public void Invalid_User_Creds_Returns_Null_User()
        {
            //Arrange
            var userRepo = new UserRepository();

            //Act
            User user = userRepo.GetUsersByCreds("bob", 5555);

            //Assert
            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public void Valid_User_Creds_Returns_User()
        {
            //Arrange
            var userRepo = new UserRepository();

            //Act
            User user = userRepo.GetUsersByCreds("roland", 1234);

            //Assert
            Assert.AreEqual(1, user.UserId);
        }




    }
}
