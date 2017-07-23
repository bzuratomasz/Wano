using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WanoControlCenter.Models;
using System.Collections.Generic;
using WCCCommon.Models;
using WanoControlCenter.Models.Schemas;

namespace WanoControlCenter.Tests.Models
{
    [TestClass]
    public class SupervisorUiModelTests
    {
        [TestMethod]
        public void SupervisorUiModel_GenerateFinalResult_ReturnNewList()
        {
            //Arrange
            List<List<Status>> newList = new List<List<Status>>();

            //Act
            var result = new SupervisorUiModel();

            //Assert
            Assert.AreEqual(result.GenerateFinalResult(newList, null), newList);
        }

        [TestMethod]
        public void SupervisorUiModel_GenerateFinalResult_ReturnSummarListVersionOne()
        {
            //Arrange
            List<List<Status>> newList = new List<List<Status>>() 
            {
                new List<Status>(){ Status.Clear, Status.Clear}
            };

            List<List<Status>> oldList = new List<List<Status>>()
                        {
                new List<Status>(){ Status.Blank, Status.Blank}
            };

            List<List<Status>> expected = new List<List<Status>>()
            {
                new List<Status>(){ Status.Clear, Status.Clear}
            };

            //Act
            var result = new SupervisorUiModel();
            var calculate = result.GenerateFinalResult(newList, oldList);

            //Assert
            Assert.AreEqual(calculate[0][0], expected[0][0]);
            Assert.AreEqual(calculate[0][1], expected[0][1]);
        }

        [TestMethod]
        public void SupervisorUiModel_GenerateFinalResult_ReturnSummarListVersionTwo()
        {
            //Arrange
            List<List<Status>> newList = new List<List<Status>>() 
            {
                new List<Status>(){ Status.Clear, Status.Set}
            };

            List<List<Status>> oldList = new List<List<Status>>()
                        {
                new List<Status>(){ Status.Set, Status.Blank}
            };

            List<List<Status>> expected = new List<List<Status>>()
            {
                new List<Status>(){ Status.Clear, Status.Set}
            };

            //Act
            var result = new SupervisorUiModel();
            var calculate = result.GenerateFinalResult(newList, oldList);

            //Assert
            Assert.AreEqual(calculate[0][0], expected[0][0]);
            Assert.AreEqual(calculate[0][1], expected[0][1]);
        }

        [TestMethod]
        public void SupervisorUiModel_GenerateFinalResult_ReturnSummarListVersionThree()
        {
            //Arrange
            List<List<Status>> newList = new List<List<Status>>() 
            {
                new List<Status>(){ Status.Blank, Status.Set}
            };

            List<List<Status>> oldList = new List<List<Status>>()
                        {
                new List<Status>(){ Status.Set, Status.Set}
            };

            List<List<Status>> expected = new List<List<Status>>()
            {
                new List<Status>(){ Status.Set, Status.Set}
            };

            //Act
            var result = new SupervisorUiModel();
            var calculate = result.GenerateFinalResult(newList, oldList);

            //Assert
            Assert.AreEqual(calculate[0][0], expected[0][0]);
            Assert.AreEqual(calculate[0][1], expected[0][1]);
        }

        [TestMethod]
        public void SupervisorUiModel_AddToContext_VerifyListCount()
        {
            //Arrange
            List<List<Status>> newList = new List<List<Status>>();

            //Act
            var result = new SupervisorUiModel();
            result.AddToContext(new ControlEntity());

            //Assert
            Assert.AreEqual(result.GetContext().Count, 1);
        }
    }
}
