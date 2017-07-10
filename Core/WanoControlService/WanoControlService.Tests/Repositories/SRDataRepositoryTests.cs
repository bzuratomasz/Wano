using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Reactive.Subjects;
using WanoControlService.Services.SRDataService;
using WCCCommon.Models;
using WCCInfrastructure.Repositories;
using WCCInfrastructure.Services.SRDataService;

namespace WanoControlService.Tests.Repositories
{
    /// <summary>
    /// Summary description for SRDataRepositoryTests
    /// </summary>
    [TestClass]
    public class SRDataRepositoryTests
    {
        public SRDataRepositoryTests()
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
        public void WanoControlService_SRDataRepository_CatchElement()
        {
            //Arrange
            var srDataService = new Mock<ISRDataService>();
            var srDataRepository = new Mock<ISRDataRepository>();

            var sendReceiveData = new Mock<SendReceiveData>();

            var subject = new Subject<SRData>();
            srDataService
                .Setup(x => x.SRData)
                .Returns(subject);

            //Act
            srDataService.Setup(x => x.SaveInteraction(sendReceiveData.Object));

            //Assert
            srDataRepository.Verify(repo => repo.OnNext(It.IsAny<SRData>()), Times.Once);
        }
    }
}
