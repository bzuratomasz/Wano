using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanoControlCenter.Views;

namespace WanoControlCenter.Models
{
    public class ControlPanelUiModel
    {
        private ManageCards _conf = new ManageCards();

        public ControlPanelUiModel()
        {

        }

        public ManageCards GetManageCards() 
        {
            return _conf;
        }
    }
}
