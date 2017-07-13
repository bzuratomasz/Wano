using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WanoControlCenter.Models;
using WanoControlCenter.Presenters;
using WanoControlCenter.Interfaces.Presenters;
using WanoControlCenter.Interfaces.Models;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlCenter.Configuration;
using System;

namespace WanoControlCenter.Tests.Presenter
{
    [TestClass]
    public class ManageCardsPresenterTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ManageCardsPresenter_RegisterCard_Success()
        {
            var serviceModel = new Mock<IServiceModel>();


            serviceModel.Setup(x => x.RegisterCard(new RequestRegisterCard() { }))
                .Returns(new ResponseRegisterCard() { });
        }
    }
}
