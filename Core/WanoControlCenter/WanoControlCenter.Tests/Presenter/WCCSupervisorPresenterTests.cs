using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WanoControlCenter.Interfaces.Presenters;
using WanoControlCenter.Models;
using WanoControlCenter.Presenters;
using xunit = Xunit;
using System.Collections.Generic;
using WCCCommon.Models;

namespace WanoControlCenter.Tests.Presenter
{
    [TestClass]
    public class WCCSupervisorPresenterTests
    {

        [TestMethod]
        public void ManageCardsPresenter_UpdateCardsPermissions_ThrowsException_BadCardId()
        {
            //Arrange
            var mngCardsP = new Mock<IWCCSupervisorPresenter>();

            //Act
            var result = new WCCSupervisorPresenter(new ServiceModel(), new SupervisorUiModel(), mngCardsP.Object);

            //Assert
            xunit.Assert.Throws<InvalidOperationException>(() => result.UpdateCardsPermissions(new List<List<Status>>() { }, 0));
        }

        [TestMethod]
        public void ManageCardsPresenter_UpdateCardsPermissions_ThrowsException_EmptyStatusList()
        {
            //Arrange
            var mngCardsP = new Mock<IWCCSupervisorPresenter>();

            //Act
            var result = new WCCSupervisorPresenter(new ServiceModel(), new SupervisorUiModel(), mngCardsP.Object);

            //Assert
            xunit.Assert.Throws<InvalidOperationException>(() => result.UpdateCardsPermissions(null, 1));
        }

        [TestMethod]
        public void ManageCardsPresenter_UpdateCardsPermissions_Success()
        {
            //Arrange
            var mngCardsP = new Mock<IWCCSupervisorPresenter>();

            //Act
            var result = new WCCSupervisorPresenter(new ServiceModel(), new SupervisorUiModel(), mngCardsP.Object);

            //Assert
            xunit.Assert.Equal(false, result.UpdateCardsPermissions(new List<List<Status>>() { new List<Status>() }, 1));
        }
    }
}
