using Assets;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformModel
{
    public partial class Messages : ObservableObject
    {
        [ObservableProperty]
        public DateTime dateTime;
        [ObservableProperty]
        public Level lever;
        [ObservableProperty]
        public string msg;

    }
}
