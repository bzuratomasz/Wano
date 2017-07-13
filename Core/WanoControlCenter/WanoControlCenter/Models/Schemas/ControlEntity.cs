using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WanoControlCenter.Controls;

namespace WanoControlCenter.Models.Schemas
{
    public class ControlEntity
    {
        public DockPanelCustom dockPanel { get; set; }

        public ButtonCustom customButton { get; set; }
    }
}
