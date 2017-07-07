using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WanoControlContracts.DataContracts.RegisterCard
{
    [DataContract]
    public class ResponseRegisterCard
    {
        [DataMember]
        public bool Registered { get; set; }
    }
}
