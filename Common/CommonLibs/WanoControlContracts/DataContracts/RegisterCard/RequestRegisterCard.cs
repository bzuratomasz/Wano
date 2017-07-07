﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WanoControlContracts.DataContracts.RegisterCard
{
    [DataContract]
    public class RequestRegisterCard
    {
          [DataMember]
          public uint CardId { get; set; }

          [DataMember]
          public bool Deleted { get; set; }

          [DataMember]
          public string Password { get; set; }

          [DataMember]
          public DateTime EndTime { get; set; }

          [DataMember]
          public DateTime StartTime { get; set; }
    }
}
