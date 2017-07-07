using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCDatabaseORM.Models.Interfaces
{
    public interface IDbConfiguration
    {
        string ConnectionString { get; set; }
    }
}
