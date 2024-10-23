using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformViewModel
{
    public partial class MQTTSendAndConfigviewModel: ObservableObject
    {
        #region 属性
        [ObservableProperty]
        MQTTClient client;
        #endregion

        #region 方法
        [RelayCommand]
        public void Connect()
        {

        }
        #endregion
    }
}
