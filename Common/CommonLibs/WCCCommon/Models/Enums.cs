using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCCommon.Models
{
    public class Enums
    {
        public Status status { get; set; }
    }

    public enum Status
    {
        Blank = 0,
        Set = 1,
        Clear = 2
    }
}
