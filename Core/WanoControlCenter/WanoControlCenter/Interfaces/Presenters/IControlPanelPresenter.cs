using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Presenters;

namespace WanoControlCenter.Interfaces.Presenters
{
    public interface IControlPanelPresenter
    {
        ControlPanelPresenter _presenter { get; set; }
    }
}
