using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Presenter;

namespace WanoControlCenter.View.Interfaces
{
    public interface IWCCSupervisorPresenter
    {
        WCCSupervisorPresenter _presenter { get; set; }
    }
}
