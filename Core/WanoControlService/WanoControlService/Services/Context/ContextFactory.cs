using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.Schemes.Main.Contexts;
using WCCDatabaseORM.Schemes.Main.Contexts.Interfaces;
using WCCInfrastructure.Configuration;
using WCCInfrastructure.Services.Context;

namespace WanoControlService.Services.Context
{
    public class ContextFactory : IContextFactory
    {
        private readonly IConfiguration _conf;

        public ContextFactory(IConfiguration conf)
        {
            _conf = conf;
        }

        //Wycieki
        public IMainDbContext DbContext
        {
            get
            {
                return new MainDbContext(_conf);
            }
        }
    }
}
