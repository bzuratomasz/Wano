using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCCDatabaseORM.AbstractionLayer;

namespace WCCDatabaseORM.Schemes.Main.Entities
{
    public class SRDataEntity : WEntity
    {
        public int Id { get; set; }

        public int DeviceId { get; set; }

        public double Frequency { get; set; }

        public double SendData { get; set; }

        public int Status { get; set; }

        public string ErrorText { get; set; }
    }
}
