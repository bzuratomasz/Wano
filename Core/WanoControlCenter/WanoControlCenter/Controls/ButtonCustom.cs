using System.Windows.Controls;
using WCCCommon.Models;

namespace WanoControlCenter.Controls
{
    public class ButtonCustom : Button
    {
        public Status Status { get; set; }
        public int IdNumber { get; set; }
    }
}
