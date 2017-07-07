using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using WCCDatabaseORM.AbstractionLayer.Interfaces;

namespace WCCDatabaseORM.AbstractionLayer
{
    public abstract class WEntityConfiguration<T> : EntityTypeConfiguration<T>, IEntityTypeConfiguration where T : class
    {
        protected WEntityConfiguration(string tableName)
        {
            this.ToTable(tableName);
        }

        public WEntityConfiguration(string tableName, string schemaName)
        {
            this.ToTable(tableName, schemaName);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            this.BuildConfiguration();
            registrar.Add(this);
        }

        public abstract void BuildConfiguration();
    }
}
