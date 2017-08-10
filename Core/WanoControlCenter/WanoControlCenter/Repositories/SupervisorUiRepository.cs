using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WanoControlCenter.Models.Schemas;
using WanoControlCenter.Repositories.Interfaces;

namespace WanoControlCenter.Repositories
{
    public class SupervisorUiRepository : ISupervisorUiRepository
    {
        private static SupervisorUiRepository _instance;
        public static SupervisorUiRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SupervisorUiRepository();
                }
                return _instance;
            }
        }

        private readonly object _syncLocker = new object();

        private List<ControlEntity> _context = new List<ControlEntity>();
        private List<GroupBox> _groupBoxes = new List<GroupBox>();

        public void AddToContext(ControlEntity item)
        {
            lock (_syncLocker)
            {
                _context.Add(item);
            }
        }

        public List<ControlEntity> GetContext()
        {
            return _context;
        }

        public void AddGroupBox(GroupBox item)
        {
            _groupBoxes.Add(item);
        }

        public List<GroupBox> GetGroupBoxes()
        {
            return _groupBoxes;
        }
    }
}
