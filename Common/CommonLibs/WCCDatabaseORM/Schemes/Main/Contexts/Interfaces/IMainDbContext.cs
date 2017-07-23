using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.Schemes.Main.Entities;

namespace WCCDatabaseORM.Schemes.Main.Contexts.Interfaces
{
    public interface IMainDbContext : IDisposable
    {
        Database Database { get; }
        IDbSet<CardsEntity> Cards { get; set; }
        DbSet<ActivityEntity> Activity { get; set; }
        DbSet<SRDataEntity> SRData { get; set; }
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
