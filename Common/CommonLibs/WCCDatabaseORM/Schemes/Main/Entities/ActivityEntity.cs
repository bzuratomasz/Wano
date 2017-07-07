using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.AbstractionLayer;

namespace WCCDatabaseORM.Schemes.Main.Entities
{
    public class ActivityEntity : WEntity
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime Time { get; set; }

        public string ActivityText { get; set; }

        public bool IsVip { get; set; }
    }
}
