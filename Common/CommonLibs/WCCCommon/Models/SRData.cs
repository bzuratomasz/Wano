using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCCommon.Models
{
    public class SRData
    {
        private SendReceiveData _data;

        public SendReceiveData Data
        {
            get { return _data; }
        }

        public SRData(SendReceiveData data)
        {
            _data = data;
        }
    }
}
