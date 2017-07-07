using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanoControlCenter.Configuration.Interfaces
{
    public interface IConfiguration
    {
        string User { get; }
        string Pass { get; }
        Dictionary<int, int> Specification { get; set; }
        string Url { get; }
    }
}
