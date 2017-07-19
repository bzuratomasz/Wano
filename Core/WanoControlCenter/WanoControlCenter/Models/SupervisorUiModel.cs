using log4net;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using WanoControlCenter.Models.Schemas;
using System.Linq;
using WanoControlCenter.Controls;
using System.Windows.Media;
using WCCCommon.Models;
using System;

namespace WanoControlCenter.Models
{
    public class SupervisorUiModel
    {
        private readonly object _syncLocker = new object();

        private List<ControlEntity> _context = new List<ControlEntity>();
        private List<GroupBox> _groupBoxes = new List<GroupBox>();

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SupervisorUiModel()
        {

        }

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

        public void ClearButtonsBackground()
        {
            var result = _context.Select(x => x.customButton);
            foreach (var item in result)
            {
                ((ButtonCustom)item).Background = Brushes.LightGray;
                ((ButtonCustom)item).Status = Status.Blank;
            }
        }

        public List<List<Status>> GenerateFinalResult(List<List<Status>> newList, List<List<Status>> oldList)
        {
            List<List<Status>> result = new List<List<Status>>();

            if (oldList != null)
            {
                foreach (var lines in newList.Zip(oldList, Tuple.Create))
                {
                    List<Status> singleRow = new List<Status>();

                    foreach (var stats in lines.Item1.Zip(lines.Item2, Tuple.Create))
                    {
                        if (stats.Item1 == Status.Blank && stats.Item2 != Status.Blank)
                        {
                            singleRow.Add(stats.Item2);
                        }
                        else
                        {
                            singleRow.Add(stats.Item1);
                        }
                    }
                    result.Add(singleRow);
                }
            }
            else 
            {
                result = newList;
            }
            return result;
        }
    }
}
