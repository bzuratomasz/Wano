using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WanoControlCenter.Models.Schemas;

namespace WanoControlCenter.Repositories.Interfaces
{
    public interface ISupervisorUiRepository
    {
        void AddToContext(ControlEntity item);
        List<ControlEntity> GetContext();
        void AddGroupBox(GroupBox item);
        List<GroupBox> GetGroupBoxes();
    }
}
