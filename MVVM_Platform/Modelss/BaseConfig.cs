using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SystemConfig;

namespace Models
{
    public partial class BaseConfig: ObservableObject
    {
        [ObservableProperty]
        string plcIp = "192.16.10.186";
        [ObservableProperty]
        int port = 1886;
        [ObservableProperty]
        bool isOpen = false;
        [ObservableProperty]
        bool isConect = false;
    }
}
