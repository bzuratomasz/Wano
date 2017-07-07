using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.AbstractionLayer.Interfaces;
using WCCDatabaseORM.Models.Interfaces;
using WCCDatabaseORM.Schemes.Main.Contexts.Interfaces;
using WCCDatabaseORM.Schemes.Main.Entities;
using WCCDatabaseORM.Schemes.Main.Mapping;

namespace WCCDatabaseORM.Schemes.Main.Contexts
{
    public class MainDbContext : DbContext, IMainDbContext
    {
        #region Fields
        private IDbConfiguration _configuration;
        #endregion

        public DbSet<CardsEntity> Cards { get; set; }
        public DbSet<ActivityEntity> Activity { get; set; }
        public DbSet<SRDataEntity> SRData { get; set; }

        public MainDbContext(IDbConfiguration configuration)
            : base(new NpgsqlConnection(configuration.ConnectionString), true)
        {
            _configuration = configuration;
            Database.SetInitializer<MainDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("wano_main");

            RegisterConfiguration<CardsConfiguration>(modelBuilder);
            RegisterConfiguration<ActivityConfiguration>(modelBuilder);
            RegisterConfiguration<SRDataConfiguration>(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }

        protected void RegisterConfiguration<Configuration>(DbModelBuilder modelBuilder) where
            Configuration : IEntityTypeConfiguration,
            new()
        {
            var configuration = new Configuration();
            configuration.AddConfiguration(modelBuilder.Configurations);
        }
    }
}
