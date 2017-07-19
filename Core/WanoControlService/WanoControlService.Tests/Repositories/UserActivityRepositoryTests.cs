using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCCInfrastructure.Repositories;
using Moq;
using WCCInfrastructure.Services.UserActivityService;
using System.Reactive.Subjects;
using WanoControlService.Repositories;
using WCCCommon.Models;

namespace WanoControlService.Tests.Repositories
{
    [TestClass]
    public class UserActivityRepositoryTests
    {
        [TestMethod]
        public void UserActivityRepository_AddElementToRepository_CountCorrect()
        {
            //Arrange
            var repo = new Mock<IDbRepository>();
            var userAct = new Mock<IUserActivityTimer>();

            var subject = new Subject<Subject<long>>();
            userAct
                .Setup(s => s.ActivityToRead)
                .Returns(subject);

            //Act
            var repoOut = new UserActivityRepository(userAct.Object, repo.Object);

            repoOut.AddActivity(new ActivityRequest() { UserName = "" });
            repoOut.AddActivity(new ActivityRequest() { UserName = "" });

            //Assert
            Assert.AreEqual(2, repoOut.ActivityListCount());
        }

        [TestMethod]
        public void UserActivityRepository_AddElementToRepository_ThrowsException()
        {
            //Arrange
            var repo = new Mock<IDbRepository>();
            var userAct = new Mock<IUserActivityTimer>();

            var subject = new Subject<Subject<long>>();
            userAct
                .Setup(s => s.ActivityToRead)
                .Returns(subject);

            //Act
            var repoOut = new UserActivityRepository(userAct.Object, repo.Object);

            try
            {
                repoOut.AddActivity(new ActivityRequest() { });
            }
            catch (Exception ex) 
            {
                Assert.AreEqual(ex.Message, "Specify UserName property please!");
            }
        }
    }
}
