using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models
{
    public partial class BaseConfig: ObservableObject
    {
        [ObservableProperty]
        bool isOpen = false;
        [ObservableProperty]
        bool isConect = false;
    }
}
