using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WanoControlCenter.Models;
using WanoControlCenter.Presenters;
using WanoControlCenter.Interfaces.Presenters;
using WanoControlCenter.Interfaces.Models;
using WanoControlContracts.DataContracts.RegisterCard;
using WanoControlCenter.Configuration;
using System;
using xunit = Xunit;
using WanoControlCenter.Configuration.Interfaces;
using System.Collections.Generic;
using WCCCommon.Models;

namespace WanoControlCenter.Tests.Presenter
{
    [TestClass]
    public class ManageCardsPresenterTests
    {
        [TestMethod]
        public void ManageCardsPresenter_RegisterCard_ThrowsException()
        {
            //Arrange
            var mngCardsP = new Mock<IManageCardsPresenter>();

            //Act
            var result = new ManageCardsPresenter(new ServiceModel(), mngCardsP.Object);

            //Assert
            xunit.Assert.Throws<InvalidOperationException>(() => result.RegisterCard(new RequestRegisterCard()
            {
                CardId = 0
            }));
        }

        [TestMethod]
        public void ManageCardsPresenter_RegisterCard_Success()
        {
            //Arrange
            var mngCardsP = new Mock<IManageCardsPresenter>();

            //Act
            var result = new ManageCardsPresenter(new ServiceModel(), mngCardsP.Object);

            //Assert
            xunit.Assert.Equal(true, result.RegisterCard(new RequestRegisterCard() { CardId = 1 }).Registered);
        }

    }
}
