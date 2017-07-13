using log4net;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using WanoControlCenter.Models.Schemas;
using System.Linq;
using WanoControlCenter.Controls;
using System.Windows.Media;
using WCCCommon.Models;

namespace WanoControlCenter.Models
{
    public class SupervisorUiModel
    {
        private List<ControlEntity> _context = new List<ControlEntity>();
        private List<GroupBox> _groupBoxes = new List<GroupBox>();

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SupervisorUiModel()
        {

        }

        public void AddToContext(ControlEntity item)
        {
            _context.Add(item);
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

        public void ClearButtonsBackground()
        {
            var result = _context.Select(x => x.customButton);
            foreach (var item in result)
            {
                ((ButtonCustom)item).Background = Brushes.LightGray;
                ((ButtonCustom)item).Status = Status.Blank;
            }
        }
    }
}
