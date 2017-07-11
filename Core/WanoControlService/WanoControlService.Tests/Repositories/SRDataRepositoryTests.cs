using Microsoft.Reactive.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Reactive.Subjects;
using WanoControlService.Repositories;
using WanoControlService.Services.SRDataService;
using WCCCommon.Models;
using WCCInfrastructure.Configuration;
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
        public void WanoControlService_SRDataRepository_CatchOneElement()
        {
            //Arrange
            var srService = new Mock<ISRDataService>();
            var dbRepository = new Mock<IDbRepository>();

            var result = new SRData(new SendReceiveData());

            var subject = new Subject<SRData>();
            srService
                .Setup(x => x.SRData)
                .Returns(subject);

            //Act
            SRDataRepository repo = new SRDataRepository(srService.Object, dbRepository.Object);
            repo.OnNext(result);

            //Assert
            dbRepository.Verify(re => re.AddSRData(result), Times.Once);
        }

        [TestMethod]
        public void WanoControlService_SRDataRepository_CatchTwoElement()
        {
            //Arrange
            var srService = new Mock<ISRDataService>();
            var dbRepository = new Mock<IDbRepository>();

            var result = new SRData(new SendReceiveData());

            var subject = new Subject<SRData>();
            srService
                .Setup(x => x.SRData)
                .Returns(subject);

            //Act
            SRDataRepository repo = new SRDataRepository(srService.Object, dbRepository.Object);
            repo.OnNext(result);
            repo.OnNext(result);

            //Assert
            dbRepository.Verify(re => re.AddSRData(result), Times.Exactly(2));
        }
    }
}
