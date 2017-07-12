using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Presenters;

namespace WanoControlCenter.Interfaces
{
    public interface IManageCardsPresenter
    {
        ManageCardsPresenter _presenter { get; set; }
    }
}
