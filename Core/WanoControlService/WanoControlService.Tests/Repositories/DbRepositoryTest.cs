using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCCInfrastructure.Repositories;
using Moq;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCDatabaseORM.Schemes.Main.Contexts.Interfaces;
using WCCDatabaseORM.Schemes.Main.Entities;
using System.Linq;
using System.Data.Entity;
using xunit = Xunit;
using WanoControlService.Repositories;
using WCCInfrastructure.Configuration;
using WCCInfrastructure.Services.Context;

namespace WanoControlService.Tests.Repositories
{
    /// <summary>
    /// Summary description for DbRepositoryTest
    /// </summary>
    [TestClass]
    public class DbRepositoryTest
    {
        public DbRepositoryTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DbRepositoryTest_GetCards_ReturnOneRow()
        {
            //Arrange
            var conf = new Mock<IConfiguration>();
            var dbcontext = new Mock<IMainDbContext>();
            var factory = new Mock<IContextFactory>();

            //Act
            var cardEntity = new List<CardsEntity>()
            {
                new CardsEntity() { 
                    CardId = 12 
                }
            }.AsQueryable();

            var cardsMock = GetDbSetMock(cardEntity);

            dbcontext
                .Setup(s => s.Cards)
                .Returns(cardsMock.Object);

            factory
                .Setup(s => s.DbContext)
                .Returns(dbcontext.Object);

            var repo = new DbRepository(conf.Object, factory.Object);

            var result = repo.GetCards().Count(w => w.CardId == 12);

            //Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void DbRepositoryTest_GetCards_ReturnTwoRows()
        {
            //Arrange
            var conf = new Mock<IConfiguration>();
            var dbcontext = new Mock<IMainDbContext>();
            var factory = new Mock<IContextFactory>();

            //Act
            var cardEntity = new List<CardsEntity>()
            {
                new CardsEntity() { 
                    CardId = 12 
                },
                new CardsEntity() { 
                    CardId = 12 
                }
            }.AsQueryable();

            var cardsMock = GetDbSetMock(cardEntity);

            dbcontext
                .Setup(s => s.Cards)
                .Returns(cardsMock.Object);

            factory
                .Setup(s => s.DbContext)
                .Returns(dbcontext.Object);

            var repo = new DbRepository(conf.Object, factory.Object);

            var result = repo.GetCards().Count();

            //Assert
            Assert.AreEqual(result, 2);
        }

        private static Mock<IDbSet<T>> GetDbSetMock<T>(IQueryable<T> callogData) where T : class
        {
            var dbSetMock = new Mock<IDbSet<T>>();

            dbSetMock.Setup(m => m.Provider).Returns(callogData.Provider);

            dbSetMock.Setup(m => m.Expression).Returns(callogData.Expression);

            dbSetMock.Setup(m => m.ElementType).Returns(callogData.ElementType);

            dbSetMock.Setup(m => m.GetEnumerator()).Returns(callogData.GetEnumerator());
            return dbSetMock;
        }
    }
}
