using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCCInfrastructure.Repositories;
using Moq;
using WanoControlService.Repositories;
using WanoControlContracts.DataContracts.RegisterCard;
using System.Collections.Generic;
using WCCCommon.Models;
using xunit = Xunit;

namespace WanoControlService.Tests.Repositories
{
    [TestClass]
    public class CardsRepositoryTests
    {
        [TestMethod]
        public void CardsRepository_AddNewCard_OneElementInDbRepository()
        {
            //Arrange
            var dbrepo = new Mock<IDbRepository>();
            var input = new RequestRegisterCard() { CardId = 1 };

            //Act
            var result = new CardsRepository(dbrepo.Object);
            result.AddCard(input);

            //Assert
            dbrepo.Verify(s => s.AddCard(input), Times.Once);
        }

        [TestMethod]
        public void CardsRepository_AddNewCard_TwoElementsInDbRepository()
        {
            //Arrange
            var dbrepo = new Mock<IDbRepository>();
            var input = new RequestRegisterCard() { CardId = 1 };

            //Act
            var result = new CardsRepository(dbrepo.Object);
            result.AddCard(input);
            result.AddCard(input);

            //Assert
            dbrepo.Verify(s => s.AddCard(input), Times.Exactly(2));
        }

        [TestMethod]
        public void CardsRepository_AddNewCard_NoElementsInDbRepository()
        {
            //Arrange
            var dbrepo = new Mock<IDbRepository>();
            var input = new RequestRegisterCard() { };

            //Act
            var result = new CardsRepository(dbrepo.Object);
            result.AddCard(input);
            result.AddCard(input);

            //Assert
            dbrepo.Verify(s => s.AddCard(input), Times.Never);
        }

        [TestMethod]
        public void CardsRepository_UpdateCardsPermissions_ReturnFalse()
        {
            //Arrange
            var dbrepo = new Mock<IDbRepository>();
            var input = new List<List<Status>>() { };

            //Act
            var result = new CardsRepository(dbrepo.Object);
            result.UpdateCardsPermissions(input, 1);

            //Assert
            Assert.AreEqual(false, result.UpdateCardsPermissions(input, 1));
        }

        [TestMethod]
        public void CardsRepository_UpdateCardsPermissions_ThrowsException()
        {
            //Arrange
            var dbrepo = new Mock<IDbRepository>();
            var input = new List<List<Status>>() { };

            //Act
            var result = new CardsRepository(dbrepo.Object);

            //Assert
            xunit.Assert.Throws<Exception>(() => result.UpdateCardsPermissions(input, 0));
        }
        
    }
}
