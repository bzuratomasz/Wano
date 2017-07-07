using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCCommon.Models
{
    public class SendReceiveData
    {
        public int DeviceId { get; set; }

        public double Frequency { get; set; }

        public double SendData { get; set; }

        public int Status { get; set; }

        public string ErrorText { get; set; }
    }
}
