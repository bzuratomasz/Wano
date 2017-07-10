using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WCCInfrastructure.Repositories;
using WanoControlService.Services.RegisterCardService;
using WanoControlContracts.DataContracts.RegisterCard;
using WCCCommon.Models;
using WanoControlService.Services.SRDataService;
using System.Reactive.Subjects;
using WCCInfrastructure.Services.SRDataService;

namespace WanoControlService.Tests.Services.RegisterCardService
{
    [TestClass]
    public class RegisterCardServiceTests
    {
        [TestMethod]
        public void WanoControlService_RegisterCard_SuccesfulyRegister()
        {
            //Arrange
            var cardRepository = new Mock<ICardsRepository>();
            var userActivityRepository = new Mock<IUserActivityRepository>();
            var srDataService = new Mock<ISRDataService>();

            var registerCardRequest = new RequestRegisterCard() 
            {
                CardId = 111,
                Deleted = false
            };

            var subject = new Subject<SRData>();
            srDataService
                .Setup(x => x.SRData)
                .Returns(subject);

            //Act
            var registerCard = new RegisterCardMainService(cardRepository.Object, userActivityRepository.Object, srDataService.Object);

            //Assert 
            registerCard.RegisterCard(registerCardRequest);
            srDataService.Verify(repo => repo.SaveInteraction(It.IsAny<SendReceiveData>()), Times.Once);
            userActivityRepository.Verify(repo => repo.AddActivity(It.IsAny<ActivityRequest>()), Times.Once);
        }

        [TestMethod]
        public void WanoControlService_RegisterCard_UnSuccesfulyRegister()
        {
            //Arrange
            var cardRepository = new Mock<ICardsRepository>();
            var userActivityRepository = new Mock<IUserActivityRepository>();
            var srDataService = new Mock<ISRDataService>();


            var subject = new Subject<SRData>();
            srDataService
                .Setup(x => x.SRData)
                .Returns(subject);

            //Act
            var registerCard = new RegisterCardMainService(cardRepository.Object, userActivityRepository.Object, srDataService.Object);

            //Assert 
            registerCard.RegisterCard(new RequestRegisterCard() { });
            srDataService.Verify(repo => repo.SaveInteraction(It.IsAny<SendReceiveData>()), Times.Never);
            userActivityRepository.Verify(repo => repo.AddActivity(It.IsAny<ActivityRequest>()), Times.Never);
        }
    }
}
