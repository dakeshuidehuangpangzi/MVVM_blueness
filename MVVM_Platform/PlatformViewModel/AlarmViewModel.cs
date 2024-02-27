using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformViewModel
{
    public partial class AlarmViewModel : ObservableObject
    {
        [ObservableProperty]
        private string ? alarmName = "报警界面";
    }
}
