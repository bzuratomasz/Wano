using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WanoControlContracts.DataContracts.ControllerConfigure
{
    [DataContract]
    public class ResponseControllerConfigure
    {
        [DataMember]
        public IPAddress Ip { get; set; }

        [DataMember]
        public IPAddress Mask { set; get; }

        [DataMember]
        public IPAddress Gateway { get; set; }

        [DataMember]
        public int Port { set; get; }

        [DataMember]
        public int HolidayControl { get; set; }

        [DataMember]
        public string PcIPAddr { set; get; }

        [DataMember]
        public int SN { set; get; }
    }
}
