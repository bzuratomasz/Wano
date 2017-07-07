using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace WCCDatabaseORM.AbstractionLayer.Interfaces
{
    public interface IEntityTypeConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}
