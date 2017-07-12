using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCCCommon.Models;

namespace WanoControlContracts.DataContracts.RegisterCard
{
    [DataContract]
    public class RequestRegisterCard
    {
        [DataMember]
        public int CardId { get; set; }

        [DataMember]
        public bool Deleted { get; set; }

        [DataMember]
        public int Password { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public string Permissions { get; set; }
    }
}
