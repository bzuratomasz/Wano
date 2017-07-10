using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WCCInfrastructure.Repositories;
using WCCInfrastructure.Services.UserActivityService;
using WCCInfrastructure.Configuration;
using Microsoft.Reactive.Testing;
using System.Threading;

namespace WanoControlService.Tests.Repositories
{
    [TestClass]
    public class UserActivityRepositoryTests
    {
        [TestMethod]
        public void WanoControlService_UserActivityRepository_FiredEvent()
        {
            var userActivityRepository = new Mock<IUserActivityRepository>();
            var userActivityTimer = new Mock<IUserActivityTimer>();
            var conf = new Mock<IConfiguration>();


        }
    }
}
