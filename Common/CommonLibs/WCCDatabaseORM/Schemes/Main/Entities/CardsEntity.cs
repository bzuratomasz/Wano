using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.AbstractionLayer;

namespace WCCDatabaseORM.Schemes.Main.Entities
{
    public class CardsEntity : WEntity
    {
        public int Id { get; set; }

        public int CardId { get; set; }

        public bool IsDeleted { get; set; }

        public int Password { get; set; }

        public DateTime YmdEnd { get; set; }

        public DateTime YmdStart { get; set; }

        public string Permissions { get; set; }
    }
}
