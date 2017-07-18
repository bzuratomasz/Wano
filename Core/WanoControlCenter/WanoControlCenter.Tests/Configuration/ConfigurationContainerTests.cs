using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WanoControlCenter.Configuration;
using WanoControlCenter.Configuration.Interfaces;
using Moq;
using System.Collections.Generic;
using xunit = Xunit;

namespace WanoControlCenter.Tests.Configuration
{
    [TestClass]
    public class ConfigurationContainerTests
    {
        private string _serializedObject = @"{                    
                            '0': '8',                    
                            '1': '4',}";

        private Dictionary<int, int> _serializedObjectTranslated = new Dictionary<int, int>() 
        { 
        {0,8},
        {1,4},
        };

        [TestMethod]
        public void ConfigurationContainerTests_LoadConfiguration_LoadSpecificationSuccess()
        {
            //Arrange
            var conf = new Mock<IConfiguration>();

            //Act
            conf.Setup(x => x.Specification)
                .Returns(_serializedObjectTranslated);

            var configuration = new ConfigurationContainer();
            var spec = configuration.LoadSpecification(_serializedObject);

            //Assert
            xunit.Assert.Equal(conf.Object.Specification, spec);
        }
    }
}
