using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.Schemes.Main.Contexts.Interfaces;

namespace WCCInfrastructure.Services.Context
{
    public interface IContextFactory
    {
        IMainDbContext DbContext { get; }
    }
}
