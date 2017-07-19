using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WCCInfrastructure.Configuration;
using System.Data.Common;
using System.Data;

namespace WanoControlService.Tests.Configurations
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void Configuration_ConnectionString_Connected()
        {
            //Arrange
            var conf = new Mock<IConfiguration>();

            string str = @"Server=localhost;Port=5432;User Id=postgres;Password=Djm600kt;Database=Main;CommandTimeout=3600;Timeout=15;MinPoolSize=5;MaxPoolSize=60;SearchPath=wano_main;ApplicationName=WanoControlService";
            conf
                .Setup(s => s.Url)
                .Returns(str);

            string provider = "Npgsql";

            //Act
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            //Assert
            using (DbConnection conn = factory.CreateConnection())
            {
                conn.ConnectionString = conf.Object.Url;
                conn.Open();

                Assert.AreEqual(false, factory.CanCreateDataSourceEnumerator);
                Assert.AreEqual(conn.State, ConnectionState.Open);
            }
        }
    }
}
