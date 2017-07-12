using System.Collections.Generic;
using System.Windows.Controls;
using WCCCommon.Models;

namespace WanoControlCenter.Controls
{
    public class ListBoxItemCustom : ListBoxItem
    {
        public List<List<Status>> Stats { get; set; }
        public int cardId { get; set; }
    }
}
