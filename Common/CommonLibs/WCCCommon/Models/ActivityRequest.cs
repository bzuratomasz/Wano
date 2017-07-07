using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCCommon.Models
{
    public class ActivityRequest
    {
        public string UserName { get; set; }

        public DateTime Time { get; set; }

        public string ActivityText { get; set; }

        public bool IsVip { get; set; }
    }
}
