using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.Schemes.Main.Entities;

namespace WCCDatabaseORM.Schemes.Main.Contexts.Interfaces
{
    public interface IMainDbContext : IDisposable
    {
        Database Database { get; }
        DbSet<CardsEntity> Cards { get; set; }
        DbSet<ActivityEntity> Activity { get; set; }
        DbSet<SRDataEntity> SRData { get; set; }
    }
}
